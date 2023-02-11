import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import VideoServis from '../Api/VideoServis/VideoServis';
import ListVideo from '../Components/ListVideo/ListVideo';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import {Navigate } from "react-router-dom";

const VideoPage = () => {

    const [videos,setVideos] = useState([]);

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const video = await VideoServis.getAll();
        setVideos([...videos,...video.data]);
      });

    useEffect(()=>{
        fetchVideo();
    },[]);

    return (
        <div>
        {isLoading && <Loader/>}
        {error && <Navigate to="/not-found" replace={true} />}
        {videos.length > 0 && 
            <ListVideo
                videos={videos}    
            />}
        </div>
    );
}

export default VideoPage;
