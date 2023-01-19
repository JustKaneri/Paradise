import React from 'react';
import AuthButtons from '../AuthButton/AuthButtons';
import AuthInput from '../AuthInput/AuthInput';
import AuthName from '../AuthName/AuthName';

const AuthLogIn = () => {
    return (
        <>
            <AuthName name = {'Paradise'}/>
            <AuthInput 
                nameLabel={'Логин'}
                inputName={'login'}
            />
            <AuthInput
                isPassword={true}
                nameLabel={'Пароль'}
                inputName={'password'}
            />
            <AuthButtons
                status = {'log'}
            />
        </>
    );
}

export default AuthLogIn;
