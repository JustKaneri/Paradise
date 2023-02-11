import React,{useEffect} from 'react';
import { useParams } from 'react-router-dom';
import ProfileCanal from '../Components/Canal/ProfileCanal/ProfileCanal';
import ListVideo from '../Components/ListVideo/ListVideo';
import VideoServis from '../Api/VideoServis/VideoServis';
import UserServis from '../Api/UserServis/UserServis';
import { useState } from 'react';
import Loader from '../Components/Loader/Loader';
import { useFetching } from '../UserHook/useFeatching';
import { Navigate } from 'react-router-dom';

const ProfilePage = () => {

    const {id} = useParams();

    const [videos,setVideos] = useState([]);
    const [user,setUser] = useState({});

    const [fetchVideo,isLoadingVideo,error] = useFetching(async () =>{
        const responce = await VideoServis.getVideoSelectUser(id);
        setVideos([...videos,...responce.data]);
    });

    const [fetchUser,isLoadingUser,errorUser] = useFetching(async () =>{
        const responce = await UserServis.getCurrentUser(id);
        setUser({...responce.data});
    });

    useEffect(()=>{
        fetchVideo();
        fetchUser();
    },[]);


    return (
        <div>
            {isLoadingUser && <Loader/>}
            {errorUser && <Navigate to="/not-found" replace={true} />}
            {user &&
                <ProfileCanal
                    user ={user}
                />
            }
            {videos.length > 0 &&
                <ListVideo
                    videos={videos} 
                />
            }
            
        </div>
    );
}

export default ProfilePage;
