import React from 'react';
import AuthButtons from './AuthButton/AuthButtons';
import AuthInput from './AuthInput/AuthInput';
import AuthName from './AuthName/AuthName';
import styles from './authWindow.module.css'

const AuthWindow = () => {
    return (
        <div className={styles.box}>
            <div className={styles.auth_back}>
                <div className={styles.box_auth}>
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
                </div>
            </div>
        </div>
    );
}

export default AuthWindow;
