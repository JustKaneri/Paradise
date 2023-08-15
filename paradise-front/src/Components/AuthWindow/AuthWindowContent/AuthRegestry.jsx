import React, { useRef, useState,useContext, useEffect } from 'react';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';
import { useFetching } from '../../../UserHook/useFeatching';
import AuthServis from '../../../Api/AuthServis/AuthServis';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../../../Context';
import CreateAlert from '../../../UserHook/useAlert';


const AuthRegestry = () => {

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [showAlert] = CreateAlert();

    const router = useNavigate();
    const nameRef = useRef(null);
    const loginRef = useRef(null);
    const passwordRef = useRef(null);
    const confirmRef = useRef(null);
    const [user,setUser] = useState({
        "name": "",
        "login": "",
        "password": "",
        "confirmPassword": ""
    });

    const [fetch,isLoading,error] = useFetching(async () =>{
        console.log(1);
        const responce = await AuthServis.regestry(user);
        if(responce.data){
            showAlert("Успешная регистрация","success")
            useTokenHook.saveTokens(responce.data);
            setIsAuth(true);
            router('/main'); 
        }
    });

    const regestry = ()=>{
        if(nameRef.current.value.trim() == '' || loginRef.current.value.trim() == '' 
           || passwordRef.current.value.trim() == '' || confirmRef.current.value.trim() == ''){
            showAlert("Вы не заполнили все поля","warning")
            return;
        }

        setUser(user => ({
            ...user,
            name: nameRef.current.value.trim(),
            login: loginRef.current.value.trim(),
            password: passwordRef.current.value.trim(),
            confirmPassword: confirmRef.current.value.trim()
        }));
    }

    useEffect(()=>{
        if(user.name == '' || user.login == '' || user.password == ''){
            return;
        }

        if(user.password != user.confirmPassword){
            showAlert("Пароли не совпадают","warning")
            return;
        }
        console.log('fetch')
        fetch();
    },[user])

    useEffect(()=>{
        console.log(error);
        if(error.response != null ){
            if(error.response.data != null)
                showAlert(error.response.data,"error")
        }
    },[error.response])

    return (
        <> 
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
                handler = {()=>regestry()}
                status = {'reg'}
            />
        </>
    );
}

export default AuthRegestry;
