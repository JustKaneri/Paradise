import React from 'react';
import styles from './videoRowItem.module.css'
import { useNavigate } from 'react-router-dom';
import VideoInfo from './VideoInfo/VideoInfo';
import getSrcUser from '../../../UserHook/useSrcUser';

const VideoRowItem = ({value,index}) => {

    const router = useNavigate();

    const src = getSrcUser.Poster(value);

    return (
        <div className={styles.box}>
            <h3 className={styles.index}>
                {index}
            </h3>
            <img 
                onClick={()=> router(`/video/${value.id}`)}
                className={styles.poster}
                src={src}/>
            <VideoInfo
                value = {value}
            />
        </div>
    );
}

export default VideoRowItem;
