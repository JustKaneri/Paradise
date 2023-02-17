import React, { useState , useContext , useEffect }  from 'react';
import UserServis from '../../../Api/UserServis/UserServis';
import AuthServis from '../../../Api/AuthServis/AuthServis';
import {AuthContext} from '../../../Context';
import useSrcUser from '../../../UserHook/useSrcUser';
import ModalContentAuth from '../../ModalWindow/ModalList/ListAuth/ModalContentAuth';
import ModalContentNotAuth from '../../ModalWindow/ModalList/ListNotAuth/ModalContentNotAuth';
import ModalMenu from '../../ModalWindow/ModalMenu/ModalMenu';
import useTokensHook from '../../../UserHook/useTokensHoouk';
import {useFetching} from '../../../UserHook/useFeatching';
import './profile.css'
import useTokenHook from '../../../UserHook/useTokensHoouk';
import images from '../../../Other/DictonaryImage';
import useRefreshToken from '../../../UserHook/useRefreshToken';

const Profile = () => {

    const[IsVisible,setIsVisible] = useState(false);
    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [user,setUser]=useState({});

    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await UserServis.getAuthUser(useTokensHook.getAccsesToken());

        setUser({...responce.data});
    });

    useRefreshToken(fetch,error);

    useEffect(()=>{
        if(IsAuth){
            fetch();
            console.log(user);
        }      
    },[]);

    const srcAva = IsAuth?useSrcUser.Avatar(user):images.profile;

    return (
        <div className='profile' onClick={()=> setIsVisible(!IsVisible)}>
            <img className='profile-img' src={srcAva}></img>          
            <ModalMenu  IsVisible = {IsVisible}> 
                {IsAuth 
                    ? <ModalContentAuth/>
                    : <ModalContentNotAuth/>
                }
            </ModalMenu>
        </div>
    );
}

export default Profile;
