import React from 'react';
import styles from './videoItem.module.css'
import {useNavigate} from 'react-router-dom';
import images from '../../../Other/DictonaryImage'

const VideoItem = (props) => {
    
    const router = useNavigate();

    const srcAva = props.videoItem.user.profile.pathAvatar == null ? images.profile : props.videoItem.user.profile.pathAvatar;

    return (
        <div onClick={()=> router(`/video/${props.videoItem.id}`)} key={props.videoItem.id} className={styles.box}>
            <img src={props.videoItem.pathPoster} 
                className={styles.video}/>
            <div className={styles.info}>
                <img src={srcAva} className={styles.profile}/>
                <span className={styles.name}>{props.videoItem.name}</span>
            </div>
            
        </div>
    );
}

export default VideoItem;
