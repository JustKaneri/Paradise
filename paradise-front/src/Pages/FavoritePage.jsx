import React, { useEffect, useState } from 'react';
import VideoServis from '../Api/VideoServis/VideoServis';
import FavoriteList from '../Components/FavoriteList/FavoriteList';
import { useFetching } from '../UserHook/useFeatching';
import useRefreshToken from '../UserHook/useRefreshToken';
import useTokenHook from '../UserHook/useTokensHoouk';
import Loader from '../Components/Loader/Loader';
import {Navigate } from "react-router-dom";

const FavoritePage = () => {

    const [video,setVideo] = useState([]);


    const [fetch,isLoading,error] = useFetching(async ()=>{
        const responce = await VideoServis.getFavoriteVideo(useTokenHook.getAccsesToken());

        setVideo([...responce.data]);
    });

    useRefreshToken(fetch,error);

    useEffect(()=>{
        fetch();
    },[])

    return (
        <div>
            {isLoading && <Loader/>}
            {video.length > 0 && 
                <FavoriteList
                    video={video}
                />
            }
        </div>
    );
}

export default FavoritePage;
