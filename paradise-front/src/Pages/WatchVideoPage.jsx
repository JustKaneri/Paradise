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
    const [comments,setComments] = useState([]);

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const videoReq = await VideoServis.getCurrentVideo(id);
        setVideo({...videoReq.data});
    });

    const [fetchComments,isLoadingComments, errorComments] = useFetching(async () =>{
        const responce = await CommentServis.getComments(id);
        setComments([ ...responce.data]);
    });

    const [fetchView, errorView] = useFetching(async () =>{
        const responce = await VideoServis.postAddView(id);
    });

    useEffect(()=>{
        fetchVideo();
        fetchComments();
    },[]);

    useEffect(()=>{
        if(Object.entries(video).length !== 0){
            fetchView();
        }
    },[video]);

    const createComment = () =>{
       fetchComments();
    }

    return (
        <div>
        {isLoading && <Loader/>}
        {error.message && <Navigate to="/not-found" replace={true} />}
        { Object.entries(video).length !== 0 &&
            <>
                    <Video 
                        video = {video}
                    />
                    <ListComments
                        handler = {createComment}
                        id = {video.id}
                        comments = {comments}
                    />
                  </>
        }
        </div>
    );
}

export default WatchVideoPage;
