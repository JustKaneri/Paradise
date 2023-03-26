import React from 'react';
import styles from './videoRowItem.module.css'
import { useNavigate } from 'react-router-dom';
import VideoInfo from './VideoInfo/VideoInfo';

const VideoRowItem = ({value,index}) => {

    const router = useNavigate();

    return (
        <div className={styles.box}>
            <h3 className={styles.index}>
                {index}
            </h3>
            <img 
                onClick={()=> router(`/video/${value.id}`)}
                className={styles.poster}
                src={value.pathPoster}/>
            <VideoInfo
                value = {value}
            />
        </div>
    );
}

export default VideoRowItem;
