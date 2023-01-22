import React, { useState } from 'react';
import ResponceDislike from './ResponceDisLike/ResponceDislike';
import ResponceLike from './ResponceLike/ResponceLike';
import styles from './videoResponce.module.css'

const VideoResponce = ({idVideo}) => {

    const [counter,setCounter] = useState({
  	  countLike: 0,
  	  countDisLike: 0
  	});

    const [responce, setResponce] = useState({
  	   videoId: idVideo,
  	   isLike: false,
  	   isDisLike: false,
  	});

    const likeClik = () =>{

        if(responce.isLike){
            //reset responce in API
            setResponce(responce => ({...responce, isLike:false}));
            setCounter(counter => ({
                ...counter,
                countLike: counter.countLike-1,
            }));
            return;
        }

        setResponce(responce => ({...responce, isLike:true}));

        let countLikeN = counter.countLike;
        let countDisLikeN = counter.countDisLike;

        if(responce.isDisLike){
          countDisLikeN  -=1;
          setResponce(responce => ({...responce, isDisLike:false}));
        }

        countLikeN +=1;

        setCounter(counter => ({ 
            ...counter,
            countLike: countLikeN,
            countDisLike: countDisLikeN 
        }))
    }

    const dislikeClick = () =>{

        if(responce.isDisLike){
            //reset responce in API

            setResponce(responce => ({...responce, isDisLike:false}));
            setCounter(counter => ({
                ...counter,
                countDisLike: counter.countDisLike-1,
            }));

            return;
        }

        setResponce(responce => ({...responce, isDisLike:true}));

        let countLikeN = counter.countLike;
        let countDisLikeN = counter.countDisLike;

        if(responce.isLike){
          countLikeN -= 1;
          setResponce(responce => ({...responce, isLike:false}));
        }

        countDisLikeN += 1;

        setCounter(counter => ({ 
            ...counter,
            countLike: countLikeN,
            countDisLike: countDisLikeN 
        }))
    }

    return (
        <div className={styles.box}>
            <ResponceLike 
                handler = {likeClik}
                countLike = {counter.countLike}  
                isLike = {responce.isLike}  
            />
            <ResponceDislike
                handler = {dislikeClick}
                countDis = {counter.countDisLike}  
                isDis = {responce.isDisLike}  
            />
        </div>
    );
}

export default VideoResponce;
