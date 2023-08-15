import React, { useEffect,useContext} from 'react';
import { useRef } from 'react';
import { useState } from 'react';
import AuthServis from '../../../Api/AuthServis/AuthServis';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';
import { useFetching } from '../../../UserHook/useFeatching';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import { useNavigate } from 'react-router-dom';
import { AuthContext} from '../../../Context';
import CreateAlert from '../../../UserHook/useAlert';

const AuthLogIn = () => {

    const router = useNavigate();
    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const [showAlert] = CreateAlert();

    const [user,setUser] = useState({
        "login": "",
        "password": ""
    });

    const refLogin = useRef(null);
    const refPassword = useRef(null);
    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await AuthServis.login(user);

        if(responce.data){
            useTokenHook.saveTokens(responce.data);
            showAlert("Вы авторизовались в системе","success")
            handler();
        }
    });
    
    const logInSystem = ()=>{
        if(refLogin.current.value.trim() == '' || refPassword.current.value.trim() == '')
        {
            showAlert("Вы не заполнили все поля","warning");
            return;
        }

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
                showAlert(error.response.data,"error");
        }
    },[error.response])

    const handler = () => {
        setIsAuth(true);
        router('/main'); 
    }

    return (
        <>
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
