import React from 'react';
import styles from './favoriteItem.module.css'
import getSrcUser from '../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';

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
            <div className={styles.video_info}>
                    <span 
                        onClick={()=> router(`/video/${value.id}`)}
                        className={styles.name}>
                        {value.name}
                    </span>
                    <div onClick={()=> router(`/profile/${value.user.id}`)}
                         className={styles.user}>
                        <img  
                            className={styles.avatar}
                            src={getSrcUser.Avatar(value.user)}/>
                        <span className={styles.user_name}>
                            {value.user.name}
                        </span>
                    </div>
            </div>
        </div>
    );
}

export default FavoriteItem;
