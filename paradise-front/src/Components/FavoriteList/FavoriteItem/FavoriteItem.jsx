import React from 'react';
import styles from './favoriteItem.module.css'
import { useNavigate } from 'react-router-dom';
import FavoriteInfo from './FavoriteInfo/FavoriteInfo';

const FavoriteItem = ({value,index}) => {

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
            <FavoriteInfo
                value = {value}
            />
        </div>
    );
}

export default FavoriteItem;
