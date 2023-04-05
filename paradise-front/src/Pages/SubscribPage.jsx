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
import PageName from '../Components/PageName/PageName';
import NotFoundContent from '../Components/NotFoundContent/NotFoundContent';

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
            <PageName
                content={'Мои подписки'}
            />
            {isLoading && <Loader/>}
            {sub.length > 0 && 
                <ListSubscrib
                    subscribs = {sub}
                />    
            }
            {!isLoading && sub.length == 0 &&
                <NotFoundContent/>
            }
        </div>
    );
}

export default SubscribPage;
