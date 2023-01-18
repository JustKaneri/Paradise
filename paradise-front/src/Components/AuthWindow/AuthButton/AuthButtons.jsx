import React from 'react';
import AuthMainButton from './AuthMainButton/AuthMainButton';
import styles from './authButtons.module.css'
import AuthSubButton from './AuthSubButton/AuthSubButton';

const AuthButtons = ({status}) => {
    return (
        <div className={styles.box}>
            <AuthMainButton 
                status = {status}
            />
            <AuthSubButton
                status = {status}
            />
        </div>
    );
}

export default AuthButtons;
