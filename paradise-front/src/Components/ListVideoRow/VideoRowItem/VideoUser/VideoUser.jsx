import React from 'react';
import getSrcUser from '../../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';
import styles from './videoUser.module.css'
import Redirect from '../../../../UserHook/useRederect';

const VideoUser = ({value}) => {

    const router = useNavigate();

    const [redirect] = Redirect(value.user.id);

    const toProfile= ()=>{
       if(redirect())
        return;

        router(`/profile/${value.user.id}`) ;
    }

    return (
        <div onClick={()=> toProfile()}
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

export default VideoUser;
