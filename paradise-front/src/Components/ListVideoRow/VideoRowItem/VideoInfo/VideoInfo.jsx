import React from 'react';
import styles from './videoInfo.module.css'
import { useNavigate } from 'react-router-dom';
import VideoUser from '../VideoUser/VideoUser';


const VideoInfo = ({value}) => {

    const router = useNavigate();

    return (
        <div className={styles.video_info}>
                    <span 
                        onClick={()=> router(`/video/${value.id}`)}
                        className={styles.name}>
                        {value.name}
                    </span>
                    <VideoUser
                        value = {value}
                    />
        </div>
    );
}

export default VideoInfo;
