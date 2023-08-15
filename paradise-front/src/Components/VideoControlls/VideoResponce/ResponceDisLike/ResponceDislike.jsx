import React, { useEffect, useState } from 'react';
import images from '../../../../Other/DictonaryImage';
import styles from './responceDislike.module.css';
import useTokenHook from '../../../../UserHook/useTokensHoouk';
import { useFetching } from '../../../../UserHook/useFeatching';
import VideoResponceServis from '../../../../Api/VideoResponceServis/VideoResponceServis';
import useRefreshToken from '../../../../UserHook/useRefreshToken';
import { useContext } from 'react';
import { AuthContext } from '../../../../Context';
import CreateAlert from '../../../../UserHook/useAlert';

const ResponceDislike = (props) => {

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [showAlert] = CreateAlert();
    const [stateResponce,setStateResponce] = useState(images.dislike);
    const[fethSetDisLike,errorDisLike] = useFetching(async () =>{
        const responce = await VideoResponceServis.setDisLikeResponce(props.id, useTokenHook.getAccsesToken());
        console.log(responce.data);
        props.handlerSet({...responce.data});
    });

    useRefreshToken(fethSetDisLike,errorDisLike);

    const dislikeClick = () =>{
        if(!IsAuth){
            showAlert("Необходима авторизация","warning");
            return;
        }

        if(props.isDis){
            props.handlerReset();
            return;
        }
        fethSetDisLike();
    }

    useEffect(()=>{
        setStateResponce(!props.isDis ?  images.dislike : images.dislikeActive);
    },[props.isDis]);
    
    return (
        <div className={styles.box}>
            <img className={styles.img} 
                 src={stateResponce}
                onClick={()=> dislikeClick()}
            />
            <span className={styles.counter}>
                {props.countDis}
            </span>  
        </div>
    );
}

export default ResponceDislike;
