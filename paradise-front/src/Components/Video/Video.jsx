import React from 'react';
import Player from 'react-custom-player';
import styles from './video.module.css';

const Video = ({video}) => {

    console.log(video);

    return (
        <div className={styles.box}>
            <Player video={video}/>
        </div>
    );
}

export default Video;
