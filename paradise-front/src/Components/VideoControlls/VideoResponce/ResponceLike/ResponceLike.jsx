import React, { useEffect, useState } from 'react';
import styles from './responceLike.module.css'
import images from '../../../../Other/DictonaryImage.js'
import useTokenHook from '../../../../UserHook/useTokensHoouk';
import { useFetching } from '../../../../UserHook/useFeatching';
import VideoResponceServis from '../../../../Api/VideoResponceServis/VideoResponceServis';
import useRefreshToken from '../../../../UserHook/useRefreshToken';
import { useContext } from 'react';
import { AuthContext } from '../../../../Context';
import CreateAlert from '../../../../UserHook/useAlert';

const ResponceLike = (props) => {

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [showAlert] = CreateAlert();
    const [stateResponce,setStateResponce] = useState(images.like);
    const[fethSetLike,errorLike] = useFetching(async () =>{
        const responce = await VideoResponceServis.setLikeResponce(props.id, useTokenHook.getAccsesToken());
        props.handlerSet({...responce.data});
    });

    useRefreshToken(fethSetLike,errorLike);
  
    const likeClik = () =>{

        if(!IsAuth)
        {
            showAlert("Необходима авторизация","warning");
            return;
        }
            

        if(props.isLike){
            props.handlerReset();
            return;
        }

        fethSetLike();
    }
    
    useEffect(()=>{
        setStateResponce(!props.isLike ?  images.like : images.likeActive);
    },[props.isLike])

    return (
        <div className={styles.box}>
            <span className={styles.counter}>
                {props.countLike}
            </span>
            <img className={styles.img} 
                src={stateResponce}
                onClick={()=> likeClik()}
            />
        </div>
    );
}

export default ResponceLike;
