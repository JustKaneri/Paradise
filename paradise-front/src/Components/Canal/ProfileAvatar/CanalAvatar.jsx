import React from 'react';
import styles from './canalAvatar.module.css'

const CanalAvatar = ({src}) => {
    return (
        <img 
            className={styles.image_ava} 
            src={src}>
        </img>
    );
}

export default CanalAvatar;
