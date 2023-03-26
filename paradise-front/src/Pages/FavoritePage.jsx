import React, { useEffect, useState } from 'react';
import VideoServis from '../Api/VideoServis/VideoServis';
import { useFetching } from '../UserHook/useFeatching';
import useRefreshToken from '../UserHook/useRefreshToken';
import useTokenHook from '../UserHook/useTokensHoouk';
import Loader from '../Components/Loader/Loader';
import PageName from '../Components/PageName/PageName'
import ListVideoRow from '../Components/ListVideoRow/ListVideoRow';

const FavoritePage = () => {

    const [video,setVideo] = useState([]);

    const [fetch,isLoading,error] = useFetching(async ()=>{
        const responce = await VideoServis.getFavoriteVideo(useTokenHook.getAccsesToken());

        setVideo([...responce.data]);
    });

    useRefreshToken(fetch,error);

    useEffect(()=>{
        fetch();
    },[])

    return (
        <div>
            <PageName
                content = {'Мои понравившиеся'}
            />
            {isLoading && <Loader/>}
            {video.length > 0 && 
                <ListVideoRow
                    video={video}
                />
            }
        </div>
    );
}

export default FavoritePage;
