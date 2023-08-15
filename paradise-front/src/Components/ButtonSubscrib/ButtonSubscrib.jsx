import React, { useState,useContext, useEffect } from 'react';
import './buttonSubscrib.css';
import {AuthContext} from '../../Context'
import { useFetching } from '../../UserHook/useFeatching';
import SubscribServis from '../../Api/SubscribServis/SubscribServis';
import useTokensHook from '../../UserHook/useTokensHoouk';
import useRefreshToken from '../../UserHook/useRefreshToken';
import CreateAlert from '../../UserHook/useAlert';

const ButtonSubscrib = ({id}) => {

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [showAlert] = CreateAlert();
    const[isSub,setIsSub] = useState(false);

    const [fetch,isLoading,error] = useFetching(async()=>{
        const responce = await SubscribServis.subscribsStatus(id , useTokensHook.getAccsesToken());
        setIsSub(responce.data);
    });

    const [fetchSub, errorSub] = useFetching(async()=>{
        const responce = await SubscribServis.subscribs(id , useTokensHook.getAccsesToken());
        setIsSub(responce.data != null);
    });

    const [fetchUnSub,errorUnSub] = useFetching(async()=>{
        const responce = await SubscribServis.unSubscribs(id , useTokensHook.getAccsesToken());
        if(responce.data != null)
        setIsSub(false);
    });

    useRefreshToken(fetch,error);
    useRefreshToken(fetchSub,errorSub);
    useRefreshToken(fetchUnSub,errorUnSub);

    const subscribe = () =>{
        if(!IsAuth){
            showAlert("Для подписки необходимо авторизоваться","warning");
            return;
        }
           

        if(!isSub){
            fetchSub();
        }
        else{
            fetchUnSub();
        }
    }

    useEffect(()=>{
        if(IsAuth){
            fetch();
        }
    },[]);

    const content = !isSub ?"Подписаться":"Отписаться";
    const styleName = !isSub? "btn btn-not-sub" : "btn btn-sub";

    return (
        <>
            {!isLoading &&
                    <button className = {styleName} onClick={()=>subscribe()}>
                        {content}
                    </button>
            }
        </>
        
        
    );
}

export default ButtonSubscrib;
