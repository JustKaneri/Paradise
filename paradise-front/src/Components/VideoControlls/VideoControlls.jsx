import React from 'react';
import styles from './videoControlls.module.css'
import VideoName from './VideoName/VideoName';

const VideoControlls = () => {

    const name = "Wdadawdjhwdkahjdjkawjhkdhwadja";

    return (
        <div className={styles.box}>
            <VideoName name={name}/>
        </div>
    );
}

export default VideoControlls;
