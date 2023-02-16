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

const Profile = () => {

    const[IsVisible,setIsVisible] = useState(false);
    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [user,setUser]=useState({});

    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await UserServis.getAuthUser(useTokensHook.getAccsesToken());

        setUser({...responce.data});
    });

    const [fetchTokens,isLoadingTokens,errorTokens] = useFetching(async () =>{
        let tokens = useTokensHook.getTokens();
        const responce = await AuthServis.updateTokens(tokens);

        useTokenHook.updateTokens(responce.data);
    });

    useEffect(()=>{
        console.log(IsAuth);
        if(IsAuth)
            fetch();
    },[]);

    useEffect(()=>{
        if(IsAuth){
            fetchTokens();
            fetch();
        }
    },[error])

    return (
        <div className='profile' onClick={()=> setIsVisible(!IsVisible)}>
            <img className='profile-img' src={useSrcUser.Avatar(user)}></img>          
            <ModalMenu 
                IsVisible = {IsVisible}
            > 
                {IsAuth 
                    ? <ModalContentAuth/>
                    : <ModalContentNotAuth/>
                }
                
            </ModalMenu>
        </div>
    );
}

export default Profile;
