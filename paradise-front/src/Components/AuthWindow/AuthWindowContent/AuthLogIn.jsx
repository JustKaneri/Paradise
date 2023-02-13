import React, { useEffect } from 'react';
import { useRef } from 'react';
import { useState } from 'react';
import AuthServis from '../../../Api/AuthServis/AuthServis';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';
import { useFetching } from '../../../UserHook/useFeatching';
import useTokenHook from '../../../UserHook/useTokensHoouk';

const AuthLogIn = () => {

    const [user,setUser] = useState({
        "login": "",
        "password": ""
    });

    const refLogin = useRef(null);
    const refPassword = useRef(null);

    const [fetch,isLoading,error] = useFetching(async () =>{
        const responce = await AuthServis.login(user);

        console.log(error);
        if(error == ''){
            console.log('save tokens');
            useTokenHook.saveTokens(responce.data);
        }  
    });

    const logInSistem = ()=>{
        setUser(user => ({
            ...user,
            login:refLogin.current.value.trim(),
            password: refLogin.current.value.trim()
        }));
    }

    useEffect(()=>{
        if(user.login == '' || user.password == '')
            return;

        fetch();
    },[user])

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
                handler = {()=>logInSistem()}
                status = {'log'}
            />
        </>
    );
}

export default AuthLogIn;
