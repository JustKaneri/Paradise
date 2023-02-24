import React, { useContext, useEffect, useState } from 'react';
import VideoResponceServis from '../../../Api/VideoResponceServis/VideoResponceServis';
import { AuthContext } from '../../../Context';
import { useFetching } from '../../../UserHook/useFeatching';
import useRefreshToken from '../../../UserHook/useRefreshToken';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import ResponceLike from './ResponceLike/ResponceLike';
import styles from './videoResponce.module.css'
import ResponceDislike from '../VideoResponce/ResponceDisLike/ResponceDislike';

const VideoResponce = ({idVideo}) => {

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [counterResponce,setCounterResponce] = useState({
        "countLike": 0,
        "countDisLike": 0
    });
    const [responce, setResponce] = useState({
        "id": 0,
        "userId": 0,
        "videoId": 0,
        "isLike": false,
        "isDisLike": false,
        "dateResponce": "2023-02-22T18:01:13.956Z"
    });

    const [fetchResponce] = useFetching(async () =>{
        const responce = await VideoResponceServis.getResponceCountVideo(idVideo);
        setCounterResponce({...responce.data});
    });

    const[fethGetResponce, isLoad ,errorResponce] = useFetching(async () =>{
        const responce = await VideoResponceServis.getResponceVideo(idVideo, useTokenHook.getAccsesToken());
        setResponce({...responce.data});
    });

    const[fethReset,errorReset] = useFetching(async () =>{
        const responce = await VideoResponceServis.resetResponce(idVideo, useTokenHook.getAccsesToken());
        setResponce({...responce.data});
    });
    
    useEffect(()=>{   
        if(IsAuth){
            fethGetResponce();
        }
    },[])

    useEffect(()=>{
        fetchResponce();
    },[responce])

    useRefreshToken(fethGetResponce,errorResponce);
    useRefreshToken(fethReset,errorReset);

    return (
        <div className={styles.box}>
            <ResponceLike 
                id = {idVideo}
                handlerSet = {setResponce}
                handlerReset = {fethReset}
                countLike = {counterResponce.countLike}  
                isLike = {responce.isLike}  
            />
            <ResponceDislike
                id = {idVideo}
                handlerSet = {setResponce}
                handlerReset = {fethReset}
                countDis = {counterResponce.countDisLike}  
                isDis = {responce.isDisLike}  
            />
        </div>
    );
}

export default VideoResponce;
