import React,{ useEffect,useState,useRef } from 'react';
import VideoServis from '../Api/VideoServis/VideoServis';
import ListVideo from '../Components/ListVideo/ListVideo';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import {Navigate } from "react-router-dom";
import {getPageCount} from '../Other/pages';;

const VideoPage = () => {

    const [videos,setVideos] = useState([]);
    const [totalPage,setTotalPage] = useState(1);
    const [page,setPage] = useState(1);
    const [limit,setLimit] = useState(16);

    const lastElement = useRef();
    const observer = useRef();

    const [fetchVideo,isLoading,error] = useFetching(async () =>{
        const responce = await VideoServis.getAll(page,limit);
        setVideos([...videos,...responce.data]);

        const totalCount = responce.headers["x-total-count"];
        setTotalPage(getPageCount(totalCount,limit));
    });

    useEffect(()=>{    
        if(isLoading) return;
        if(observer.current) observer.current.disconnect();
        var callback = function(entries,observer){
            if(entries[0].isIntersecting && (page < totalPage)){
                setPage(page+1);
            }
        }
        observer.current = new IntersectionObserver(callback);
        observer.current.observe(lastElement.current);
    },[isLoading])

    useEffect(()=>{
        fetchVideo();
    },[page]);

    return (
        <div>
        {error.message && <Navigate to="/not-found" replace={true} />}
        {videos.length > 0 && 
            <ListVideo
                videos={videos}    
            />
        }
        {isLoading && <Loader/>}
        <div ref={lastElement} style={{height:'10px',width:'90vw'}}/>
        </div>
    );
}

export default VideoPage;
