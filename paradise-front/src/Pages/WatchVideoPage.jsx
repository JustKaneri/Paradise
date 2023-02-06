import React from 'react';
import { useState, useEffect } from 'react';
import DiscriptVideo from '../Components/DiscriptVideo/DiscriptVideo';
import ListComments from '../Components/ListComments/ListComments';
import Video from '../Components/Video/Video';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import NotFound from '../Components/NotFound/NotFound';
import VideoServis from '../Api/VideoServis/VideoServis';
import { useParams } from 'react-router-dom';


const WatchVideoPage = () => {

    const {id} = useParams();
    console.log(id);
    const [video,setVideo] = useState(null);

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const videoReq = await VideoServis.getCurrentVideo(id);
        setVideo({...videoReq.data});
      });

    useEffect(()=>{
        fetchVideo();
    },[]);

    return (
        <div>
        {isLoading == false
            ?<>
                <Video 
                    video = {video}
                />
                <ListComments/>
             </>
            : <Loader/>
        }
            
        </div>
    );
}

export default WatchVideoPage;
