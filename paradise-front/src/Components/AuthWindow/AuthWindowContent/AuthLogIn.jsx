import React, { useEffect } from 'react';
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

const AuthLogIn = () => {

    const [user,setUser] = useState({
        "login": "",
        "password": ""
    });

    const[modal,closeModal,showModal] = useModal();

    const refLogin = useRef(null);
    const refPassword = useRef(null);

    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await AuthServis.login(user);

        console.log(error);

        if(responce.data){
            showModal(images.ok,'Успешно','Вы авторизовались в системе');
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
        if(error != '')
            showModal(images.error,'Упссс...',error);
    },[error])

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
