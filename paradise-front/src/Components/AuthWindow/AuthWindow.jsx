import React from 'react';
import styles from './authWindow.module.css'
import AuthLogIn from './AuthWindowContent/AuthLogIn';
import AuthRegestry from './AuthWindowContent/AuthRegestry';

const AuthWindow = ({type}) => {
    return (
        <div className={styles.box}>
            <div className={styles.auth_back}>
                <div className={styles.box_auth}>
                {type == 'auth'
                    ?<AuthLogIn/>
                    :<AuthRegestry/> 
                }   
                </div>
            </div>
        </div>
    );
}

export default AuthWindow;
