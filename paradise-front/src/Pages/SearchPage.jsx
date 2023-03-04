import React,{ useEffect,useState,useRef } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PageName from '../Components/PageName/PageName'
import VideoServis from '../Api/VideoServis/VideoServis';
import ListVideo from '../Components/ListVideo/ListVideo';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import {Navigate } from "react-router-dom";
import {getPageCount} from '../Other/pages';

const SearchPage = () => {

    const {searh} = useParams();
    let firstRender = null;
    const router = useNavigate();

    if(searh.trim() === '')
        router('/main');

    const [videos,setVideos] = useState([]);
    const [totalPage,setTotalPage] = useState(1);
    const [page,setPage] = useState({
        countPage: 1,
        limit:16
    });

    const lastElement = useRef();
    const observer = useRef();

    const [fetchVideo,isLoading,error] = useFetching(async () =>{

        const responce = await VideoServis.findVideo(page.countPage,page.limit,searh);
        setVideos([...videos,...responce.data]);

        const totalCount = responce.headers["x-total-count"];
        setTotalPage(getPageCount(totalCount,page.limit));
    });

    useEffect(()=>{    
        if(isLoading) return;
        if(observer.current) observer.current.disconnect();
        var callback = function(entries,observer){
            if(entries[0].isIntersecting && (page.countPage < totalPage)){
                setPage(page => ({...page,countPage: page.countPage + 1}));
            }
        }
        observer.current = new IntersectionObserver(callback);
        observer.current.observe(lastElement.current);
    },[isLoading])

    useEffect(()=>{
        fetchVideo();
    },[page]);

    useEffect(()=>{
        if(!firstRender){
            setVideos([]);
            setPage(page => ({...page,countPage:1}));
        }
    },[searh])

    useEffect(()=>{
        firstRender = 'render';
    },[])

    return (
        <div>
            <PageName
                content = {'Результаты поиска: '}
            />
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

export default SearchPage;
