import React from 'react';
import { useState } from 'react';
import { Navigate } from 'react-router-dom';
import ListSubscrib from '../Components/ListSubscib/ListSubscrib';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import SubscribServis from '../Api/SubscribServis/SubscribServis';
import useTokenHook from '../UserHook/useTokensHoouk';
import useRefreshToken from '../UserHook/useRefreshToken';
import { useEffect } from 'react';

const SubscribPage = () => {

    const[sub,setSub] = useState([]);

    const[feth,isLoading,error] = useFetching(async()=>{
        const responce = await SubscribServis.getSubscrib(useTokenHook.getAccsesToken());
        setSub([...sub,...responce.data])
    });

    useRefreshToken(feth,error);

    useEffect(()=>{
        feth();
    },[])
    
    return (
        <div>
            {isLoading && <Loader/>}
            {error.message && <Navigate to="/not-found" replace={true} />}
            {sub.length > 0 && 
                <ListSubscrib
                    subscribs = {sub}
                />    
            }
        </div>
    );
}

export default SubscribPage;
