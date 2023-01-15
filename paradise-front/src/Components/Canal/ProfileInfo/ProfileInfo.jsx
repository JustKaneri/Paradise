import React from 'react';
import styles from './profileInfo.module.css';

const ProfileInfo = () => {
    return (
        <div className={styles.block}>
            <span className={styles.info}>
                Подписчиков: 
            </span>
            <span className={styles.info}>
                Просмотров: 
            </span>
        </div>
    );
}

export default ProfileInfo;
