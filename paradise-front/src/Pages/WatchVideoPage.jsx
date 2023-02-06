import React from 'react';
import { useState } from 'react';
import DiscriptVideo from '../Components/DiscriptVideo/DiscriptVideo';
import ListComments from '../Components/ListComments/ListComments';
import Video from '../Components/Video/Video';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import NotFound from '../Components/NotFound/NotFound';


const WatchVideoPage = () => {

    const [videos,setVideos] = useState([]);

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const video = await VideoServis.getAll();
        setVideos([...videos,...video.data]);
      });

    useEffect(()=>{
        fetchVideo();
        console.log(videos);
    },[]);


    const video = {
        src: 'https://localhost:7077/videos/1682f9c30-03a8-48e6-b850-64a010c273d520221202192821529.mp4',
        poster:''
    }
    
    return (
        <div>
            <Video 
                video = {video}
            />
            <ListComments/>
        </div>
    );
}

export default WatchVideoPage;
