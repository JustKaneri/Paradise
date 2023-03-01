import React from 'react';
import styles from './favoriteInfo.module.css';
import getSrcUser from '../../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';
import FavoriteUser from '../FavoriteUser/FavoriteUser';


const FavoriteInfo = ({value}) => {

    const router = useNavigate();

    return (
        <div className={styles.video_info}>
                    <span 
                        onClick={()=> router(`/video/${value.id}`)}
                        className={styles.name}>
                        {value.name}
                    </span>
                    <FavoriteUser
                        value = {value}
                    />
        </div>
    );
}

export default FavoriteInfo;
