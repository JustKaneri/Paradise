import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import VideoServis from '../Api/VideoServis/VideoServis';
import ListVideo from '../Components/ListVideo/ListVideo';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import NotFound from '../Components/NotFound/NotFound';

const VideoPage = () => {

    const [videos,setVideos] = useState([]);

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const video = await VideoServis.getAll();
        setVideos([...videos,...video.data]);
      });

    useEffect(()=>{
        fetchVideo();
        console.log(videos);
    },[]);

    return (
        <div>
        {isLoading
            ? <Loader/>
            : videos.length > 0
                ? <ListVideo
                    videos={videos}    
                  />
                : <NotFound/>
        }
        </div>
    );
}

export default VideoPage;
