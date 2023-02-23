import React, { useState } from 'react';
import styles from './responceLike.module.css'
import images from '../../../../Other/DictonaryImage.js'
import useTokenHook from '../../../../UserHook/useTokensHoouk';
import { useFetching } from '../../../../UserHook/useFeatching';
import VideoResponceServis from '../../../../Api/VideoResponceServis/VideoResponceServis';
import useRefreshToken from '../../../../UserHook/useRefreshToken';

const ResponceLike = (props) => {

    const[fethSetLike,errorLike] = useFetching(async () =>{
        const responce = await VideoResponceServis.setLikeResponce(props.id, useTokenHook.getAccsesToken());
        props.handlerSet({...responce.data});
    });

    useRefreshToken(fethSetLike,errorLike);
  
    const likeClik = () =>{

        if(props.isLike){
            props.handlerReset();
            return;
        }

        fethSetLike();
    }

    const srcImg = !props.isLike ?  images.like : images.likeActive;

    return (
        <div className={styles.box}>
            <span className={styles.counter}>
                {props.countLike}
            </span>
            <img className={styles.img} 
                 src={srcImg}
                onClick={()=> likeClik()}
            />
        </div>
    );
}

export default ResponceLike;
