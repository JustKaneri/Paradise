import React from 'react';
import styles from './profileVideoItem.module.css'
import { useNavigate } from 'react-router-dom';
import VideoInfo from '../../ListVideoRow/VideoRowItem/VideoInfo/VideoInfo';

const ProfileVideoItem = ({item,index}) => {

    const router = useNavigate();

    return (
        <div className={styles.box}>
            <h3 className={styles.index}>
                {index}
            </h3>
            <img 
                onClick={()=> router(`/video/${item.id}`)}
                className={styles.poster}
                src={item.pathPoster}/>
            <VideoInfo
                value = {item}
            />
            <button
                onClick={()=> alert('В процессе...')} 
                className={styles.btn_del}>
                Удалить
            </button>
        </div>
    );
}

export default ProfileVideoItem;
