import React, { useContext, useEffect, useState } from 'react';
import VideoResponceServis from '../../../Api/VideoResponceServis/VideoResponceServis';
import { AuthContext } from '../../../Context';
import { useFetching } from '../../../UserHook/useFeatching';
import useRefreshToken from '../../../UserHook/useRefreshToken';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import ResponceDislike from './ResponceDisLike/ResponceDislike';
import ResponceLike from './ResponceLike/ResponceLike';
import styles from './videoResponce.module.css'

const VideoResponce = ({idVideo}) => {

    const {IsAuth} = useContext(AuthContext);
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

    const[fethGetResponce,errorResponce] = useFetching(async () =>{
        const responce = await VideoResponceServis.getResponceVideo(idVideo, useTokenHook.getAccsesToken());
        setResponce({...responce.data});
    });

    const[fethSetLike,errorLike] = useFetching(async () =>{
        const responce = await VideoResponceServis.setLikeResponce(idVideo, useTokenHook.getAccsesToken());
        setResponce({...responce.data});
    });

    const[fethSetDisLike,errorDisLike] = useFetching(async () =>{
        const responce = await VideoResponceServis.setDisLikeResponce(idVideo, useTokenHook.getAccsesToken());
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
    useRefreshToken(fethSetLike,errorLike);
    useRefreshToken(fethSetDisLike,errorDisLike);
    useRefreshToken(fethReset,errorReset);

    const likeClik = () =>{

        if(responce.isLike){
            fethReset();
            return;
        }

        fethSetLike();
    }

    const dislikeClick = () =>{

        if(responce.isDisLike){
            fethReset();
            return;
        }

        fethSetDisLike();
    }

    return (
        <div className={styles.box}>
            <ResponceLike 
                handler = {likeClik}
                countLike = {counterResponce.countLike}  
                isLike = {responce.isLike}  
            />
            <ResponceDislike
                handler = {dislikeClick}
                countDis = {counterResponce.countDisLike}  
                isDis = {responce.isDisLike}  
            />
        </div>
    );
}

export default VideoResponce;
