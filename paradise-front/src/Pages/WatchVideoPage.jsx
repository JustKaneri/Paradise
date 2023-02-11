import React from 'react';
import { useState, useEffect } from 'react';
import ListComments from '../Components/ListComments/ListComments';
import Video from '../Components/Video/Video';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import VideoServis from '../Api/VideoServis/VideoServis';
import CommentServis from '../Api/CommentsServis/CommentServis';
import VideoResponceServis from '../Api/VideoResponceServis/VideoResponceServis';
import { useParams, Navigate  } from 'react-router-dom';

const WatchVideoPage = () => {

    const {id} = useParams();

    const [video,setVideo] = useState({});
    const [counterResponce,setCounterResponce] = useState({});
    const [comments,setComments] = useState([]);

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const videoReq = await VideoServis.getCurrentVideo(id);
        setVideo({...videoReq.data});
    });

    const [fetchResponce,isLoadingRespon, errorRespon] = useFetching(async () =>{
        const responce = await VideoResponceServis.getResponceVideo(id);
        setCounterResponce({...responce.data});
    });

    const [fetchComments,isLoadingComments, errorComments] = useFetching(async () =>{
        const responce = await CommentServis.getComments(id);
        setComments([...comments, ...responce.data]);
    });

    useEffect(()=>{
        fetchVideo();
        fetchResponce();
        fetchComments();
    },[]);

    return (
        <div>
        {isLoading && <Loader/>}
        {error && <Navigate to="/not-found" replace={true} />}
        { Object.entries(video).length !== 0 &&
            <>
                    <Video 
                        video = {video}
                        countResponce = {counterResponce}
                    />
                    <ListComments
                        comments = {comments}
                    />
                  </>
        }
        </div>
    );
}

export default WatchVideoPage;
