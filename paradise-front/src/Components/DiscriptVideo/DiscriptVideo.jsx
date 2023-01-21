import React from 'react';
import styles from './discriptVideo.module.css';

const DiscriptVideo = ({content}) => {
    return (
        <div className={styles.box}>
            <h3 className={styles.title}>Описание:</h3>
            <span className={styles.discript}>
                {content}
            </span>
        </div>
    );
}

export default DiscriptVideo;
