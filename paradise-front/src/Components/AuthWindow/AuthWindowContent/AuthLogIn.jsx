import React, { useEffect,useContext} from 'react';
import { useRef } from 'react';
import { useState } from 'react';
import AuthServis from '../../../Api/AuthServis/AuthServis';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';
import { useFetching } from '../../../UserHook/useFeatching';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import ModalInfoWindow from '../../ModalWindow/ModalInfoWindow/ModalInfoWindow';
import useModal from '../../../UserHook/useModal';
import images from '../../../Other/DictonaryImage';
import { useNavigate } from 'react-router-dom';
import {AuthContext} from '../../../Context';

const AuthLogIn = () => {

    const router = useNavigate();
    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [user,setUser] = useState({
        "login": "",
        "password": ""
    });

    const[modal,closeModal,showModal] = useModal();
    const refLogin = useRef(null);
    const refPassword = useRef(null);
    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await AuthServis.login(user);

        if(responce.data){
            showModal(images.ok,'Успешно','Вы авторизовались в системе', handler);
            useTokenHook.saveTokens(responce.data);
        }
    });
    
    const logInSystem = ()=>{
        setUser(user => ({
            ...user,
            login:refLogin.current.value.trim(),
            password: refPassword.current.value.trim()
        }));
    }

    useEffect(()=>{
        if(user.login == '' || user.password == '')
            return;
        fetch();
    },[user])

    useEffect(()=>{
        if(error.response != null ){
            if(error.response.data != null)
                showModal(images.error,'Упссс...',error.response.data);
        }
    },[error.response])

    const handler = () => {
        setIsAuth(true);
        router('/main'); 
    }

    return (
        <>
            <ModalInfoWindow
                modal = {modal}
                handler = {closeModal}
            />
            <AuthName name = {'Paradise'}/>
            <AuthInput 
                nameLabel={'Логин'}
                inputName={'login'}
                refInput = {refLogin}
            />
            <AuthInput
                isPassword={true}
                nameLabel={'Пароль'}
                inputName={'password'}
                refInput = {refPassword}
            />
            <AuthButtons
                handler = {()=>logInSystem()}
                status = {'log'}
            />
        </>
    );
}

export default AuthLogIn;
