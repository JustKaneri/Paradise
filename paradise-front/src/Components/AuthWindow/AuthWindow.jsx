import React from 'react';
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
                        nameLabel={'Пароль'}
                        inputName={'password'}
                    />
                </div>
            </div>
        </div>
    );
}

export default AuthWindow;
