import React from 'react';
import styles from './videoItem.module.css'

const VideoItem = ({videoItem}) => {
    return (
        <div onClick={()=> alert(videoItem.id)} key={videoItem.id} className={styles.box}>
            <img src={videoItem.pathPoster} className={styles.video}/>
            <div className={styles.info}>
                <img src={videoItem.user.profile.pathAvatar} className={styles.profile}/>
                <span className={styles.name}>{videoItem.name}</span>
            </div>
            
        </div>
    );
}

export default VideoItem;
