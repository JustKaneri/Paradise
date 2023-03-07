import React from 'react';
import styles from './profileVideoItem.module.css'
import FavoriteInfo from '../../FavoriteList/FavoriteItem/FavoriteInfo/FavoriteInfo'
import { useNavigate } from 'react-router-dom';

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
            <FavoriteInfo
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
