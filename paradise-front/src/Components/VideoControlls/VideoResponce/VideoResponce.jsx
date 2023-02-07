import React, { useState } from 'react';
import ResponceDislike from './ResponceDisLike/ResponceDislike';
import ResponceLike from './ResponceLike/ResponceLike';
import styles from './videoResponce.module.css'

const VideoResponce = ({idVideo,countResponce}) => {

    const [responce, setResponce] = useState({
  	   videoId: idVideo,
  	   isLike: false,
  	   isDisLike: false,
  	});


    const likeClik = () =>{

        if(responce.isLike){
            //reset responce in API
            setResponce(responce => ({...responce, isLike:false}));
            
            return;
        }

        setResponce(responce => ({...responce, isLike:true}));
    }

    const dislikeClick = () =>{

        if(responce.isDisLike){
            //reset responce in API

            setResponce(responce => ({...responce, isDisLike:false}));


            return;
        }

        setResponce(responce => ({...responce, isDisLike:true}));
    }

    return (
        <div className={styles.box}>
            <ResponceLike 
                handler = {likeClik}
                countLike = {countResponce.countLike}  
                isLike = {responce.isLike}  
            />
            <ResponceDislike
                handler = {dislikeClick}
                countDis = {countResponce.countDisLike}  
                isDis = {responce.isDisLike}  
            />
        </div>
    );
}

export default VideoResponce;
