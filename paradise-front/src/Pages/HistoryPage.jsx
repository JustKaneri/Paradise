import React,{useState,useEffect} from 'react';
import PageName from '../Components/PageName/PageName';
import ListVideoRow from '../Components/ListVideoRow/ListVideoRow';
import useTokenHook from '../UserHook/useTokensHoouk';
import useRefreshToken from '../UserHook/useRefreshToken';
import { useFetching } from '../UserHook/useFeatching';
import Loader from '../Components/Loader/Loader';
import HistoryServis from '../Api/HistoryServis/HistoryServis';

const HistoryPage = () => {

    const [video,setVideo] = useState([]);

    const [fetch,isLoading,error] = useFetching(async ()=>{
        const responce = await  HistoryServis.getHistory(useTokenHook.getAccsesToken());

        setVideo([...responce.data]);
    });

    useRefreshToken(fetch,error);

    useEffect(()=>{
        fetch();
    },[])

    return (
        <div>
            <PageName
                content = {'История просмотров'}
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

export default HistoryPage;
