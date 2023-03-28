import React from 'react';
import styles from './videoItem.module.css'
import {useNavigate} from 'react-router-dom';
import getSrcUser from '../../../UserHook/useSrcUser';

const VideoItem = (props) => {
    
    const router = useNavigate();

    return (
        <div onClick={()=> router(`/video/${props.videoItem.id}`)} key={props.videoItem.id} className={styles.box}>
            <span className={styles.name}>{props.videoItem.name}</span>
            <img src={props.videoItem.pathPoster} 
                className={styles.video}/>
            <div className={styles.user}>
                <img src={getSrcUser.Avatar(props.videoItem.user)} className={styles.profile}/>
                <span className={styles.name_profile}>{props.videoItem.user.name}</span>
            </div>
           
        </div>
    );
}

export default VideoItem;
