import React from 'react';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';


const AuthRegestry = () => {
    return (
        <>
            <AuthName name = {'Paradise'}/>
            <AuthInput 
                nameLabel={'Имя'}
                inputName={'name'}
            />
            <AuthInput 
                nameLabel={'Логин'}
                inputName={'login'}
            />
            <AuthInput
                isPassword={true}
                nameLabel={'Пароль'}
                inputName={'password'}
            />
            <AuthInput
                isPassword={true}
                nameLabel={'Подтвердите пароль'}
                inputName={'password_confirm'}
            />
            <AuthButtons
                status = {'reg'}
            />
        </>
    );
}

export default AuthRegestry;
