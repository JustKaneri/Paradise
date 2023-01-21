import React from 'react';
import styles from './videoName.module.css';

const VideoName = ({name}) => {
    return (
        <span className={styles.name}>
            {name}
        </span>
    );
}

export default VideoName;
