import React from 'react';
import styles from './videoUser.module.css'
import images from '../../../Other/DictonaryImage';
import { useNavigate } from 'react-router-dom';
import getSrcUser from '../../../UserHook/useSrcUser';

const VideoUser = ({userInfo}) => {

  const router = useNavigate();

    return (
        <div className={styles.box}
             onClick={()=> router(`/profile/${userInfo.id}`)}
        >
          <img className={styles.image} src={getSrcUser.Avatar(userInfo)} />
          <span className={styles.name}>{userInfo.name}</span>   
        </div>
    );
}

export default VideoUser;
