import React from 'react';
import images from '../../../../Other/DictonaryImage';
import styles from './responceDislike.module.css';
import useTokenHook from '../../../../UserHook/useTokensHoouk';
import { useFetching } from '../../../../UserHook/useFeatching';
import VideoResponceServis from '../../../../Api/VideoResponceServis/VideoResponceServis';
import useRefreshToken from '../../../../UserHook/useRefreshToken';

const ResponceDislike = (props) => {

    const[fethSetDisLike,errorDisLike] = useFetching(async () =>{
        const responce = await VideoResponceServis.setDisLikeResponce(props.id, useTokenHook.getAccsesToken());
        console.log(responce.data);
        props.handlerSet({...responce.data});
    });

    useRefreshToken(fethSetDisLike,errorDisLike);

    const dislikeClick = () =>{
        if(props.isDis){
            props.handlerReset();
            return;
        }

        fethSetDisLike();
    }

    const srcImg = !props.isDis ?  images.dislike : images.dislikeActive;
    
    return (
        <div className={styles.box}>
            <img className={styles.img} 
                 src={srcImg}
                onClick={()=> dislikeClick()}
            />
            <span className={styles.counter}>
                {props.countDis}
            </span>  
        </div>
    );
}

export default ResponceDislike;
