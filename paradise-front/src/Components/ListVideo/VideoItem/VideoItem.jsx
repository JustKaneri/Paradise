import React from 'react';
import styles from './videoItem.module.css'
import {useNavigate} from 'react-router-dom';

const VideoItem = (props) => {
    
    const router = useNavigate();

    return (
        <div onClick={()=> router(`/video/:${props.key}`)} key={props.videoItem.id} className={styles.box}>
            <img src={props.videoItem.pathPoster} className={styles.video}/>
            <div className={styles.info}>
                <img src={props.videoItem.user.profile.pathAvatar} className={styles.profile}/>
                <span className={styles.name}>{props.videoItem.name}</span>
            </div>
            
        </div>
    );
}

export default VideoItem;
