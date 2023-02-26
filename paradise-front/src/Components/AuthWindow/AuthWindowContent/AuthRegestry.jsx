import React, { useRef, useState,useContext } from 'react';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';
import ModalInfoWindow from '../../ModalWindow/ModalInfoWindow/ModalInfoWindow';
import useModal from '../../../UserHook/useModal';
import { useFetching } from '../../../UserHook/useFeatching';
import AuthServis from '../../../Api/AuthServis/AuthServis';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../../../Context';
import images from '../../../Other/DictonaryImage';


const AuthRegestry = () => {

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const router = useNavigate();
    const nameRef = useRef(null);
    const loginRef = useRef(null);
    const passwordRef = useRef(null);
    const confirmRef = useRef(null);
    const [modal,closeModal,showModal,setHandler] = useModal();
    const [user,setUser] = useState({});

    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await AuthServis.regestry(user);
        if(responce.data){
            setHandler(()=>{ router('/main'); setIsAuth(true)});
            showModal(images.ok,'Успешно','Вы авторизовались в системе');
            useTokenHook.saveTokens(responce.data);
        }
    });

    return (
        <>  
            <ModalInfoWindow
                modal = {modal}
                handler = {closeModal}
            />
            <AuthName name = {'Paradise'}/>
            <AuthInput 
                nameLabel={'Имя'}
                inputName={'name'}
                refInput = {nameRef}
            />
            <AuthInput 
                nameLabel={'Логин'}
                inputName={'login'}
                refInput = {loginRef}
            />
            <AuthInput
                isPassword={true}
                nameLabel={'Пароль'}
                inputName={'password'}
                refInput = {passwordRef}
            />
            <AuthInput
                isPassword={true}
                nameLabel={'Подтвердите пароль'}
                inputName={'password_confirm'}
                refInput = {confirmRef}
            />
            <AuthButtons
                status = {'reg'}
            />
        </>
    );
}

export default AuthRegestry;
