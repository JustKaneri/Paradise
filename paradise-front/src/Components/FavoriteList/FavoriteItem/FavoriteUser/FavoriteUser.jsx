import React from 'react';
import getSrcUser from '../../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';
import styles from './favoriteUser.module.css'

const FavoriteUser = ({value}) => {

    const router = useNavigate();

    return (
        <div onClick={()=> router(`/profile/${value.user.id}`)}
                         className={styles.user}>
                        <img  
                            className={styles.avatar}
                            src={getSrcUser.Avatar(value.user)}/>
                        <span className={styles.user_name}>
                            {value.user.name}
                        </span>
        </div>
    );
}

export default FavoriteUser;
