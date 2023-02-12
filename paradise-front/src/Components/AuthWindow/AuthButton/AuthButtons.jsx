import React from 'react';
import AuthMainButton from './AuthMainButton/AuthMainButton';
import styles from './authButtons.module.css'
import AuthSubButton from './AuthSubButton/AuthSubButton';
import { useNavigate } from 'react-router-dom';

const AuthButtons = ({status, handler}) => {

    const router = useNavigate();
    const path = status == 'log'? '/regestry':'/login';

    return (
        <div className={styles.box}>
            <AuthMainButton 
                handler={handler}
                status = {status}
            />
            <AuthSubButton
                handler={()=>router(path)}
                status = {status}
            />
        </div>
    );
}

export default AuthButtons;
