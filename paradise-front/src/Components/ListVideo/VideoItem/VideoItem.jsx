import React from 'react';
import styles from './videoItem.module.css'

const VideoItem = ({videoItem}) => {

    console.log(videoItem.id);

    return (
        <div key={videoItem.id} className={styles.box}>
            <img src={videoItem.pathPoster} className={styles.video}/>
            <img src={videoItem.user.pathAvatar} className={styles.profile}/>
            <span>{VideoItem.name}</span>
        </div>
    );
}

export default VideoItem;
