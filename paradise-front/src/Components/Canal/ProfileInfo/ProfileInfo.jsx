import React from 'react';
import styles from './profileInfo.module.css';

const ProfileInfo = () => {
    return (
        <div className={styles.block}>
            <span className={styles.info}>
                Подписчиков: 0
            </span>
            <span className={styles.info}>
                Просмотров: 0
            </span>
        </div>
    );
}

export default ProfileInfo;
