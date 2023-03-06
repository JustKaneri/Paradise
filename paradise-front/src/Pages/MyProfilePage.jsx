import React from 'react';
import { useState, useEffect } from 'react';
import getId from '../UserHook/useGetId';
import UserServis from '../Api/UserServis/UserServis';
import { useFetching } from '../UserHook/useFeatching';
import VideoServis from '../Api/VideoServis/VideoServis';
import Loader from '../Components/Loader/Loader';
import { Navigate } from 'react-router-dom';
import ProfileCanal from '../Components/Canal/ProfileCanal/ProfileCanal';
import useRefreshToken from '../UserHook/useRefreshToken';
import useTokenHook from '../UserHook/useTokensHoouk';

const MyProfilePage = () => {

    const [videos,setVideos] = useState([]);
    const [user,setUser] = useState({});

    const [fetchVideo,isLoadingVideo,error] = useFetching(async () =>{
        const responce = await VideoServis.getVideoSelectUser(getId());
        setVideos([...videos,...responce.data]);
    });

    const [fetchUser,isLoadingUser,errorUser] = useFetching(async () =>{
        const responce = await UserServis.getAuthUser(useTokenHook.getAccsesToken());
        setUser({...responce.data});
    });

    useEffect(()=>{
        //fetchVideo();
        fetchUser();
    },[]);

    useRefreshToken(fetchUser,errorUser);

    return (
        <div>   
            {isLoadingUser && <Loader/>}
            {Object.entries(user).length !== 0  &&
                <ProfileCanal
                    user ={user}
                    isMy = {true}
                />
            }
        </div>
    );
}

export default MyProfilePage;
