import React from 'react';
import styles from './videoUser.module.css'

const VideoUser = () => {
    return (
        <div className={styles.box}>
          <img className={styles.image} src='https://svinki.ru/media/original_images/s1200.jpg'/>
          <span className={styles.name}>Name user</span>   
        </div>
    );
}

export default VideoUser;
