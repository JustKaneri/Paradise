import React from 'react';
import styles from './videoUser.module.css'
import images from '../../../Other/DictonaryImage';
import { useNavigate } from 'react-router-dom';
import getSrcUser from '../../../UserHook/useSrcUser';
import Redirect from '../../../UserHook/useRederect';

const VideoUser = ({userInfo}) => {

  const router = useNavigate();

  const [redirect] = Redirect(userInfo.id);

  const toProfile= ()=>{

       if(redirect())
        return;

        router(`/profile/${userInfo.id}`) ;
  }

    return (
        <div className={styles.box}
             onClick={()=> toProfile()}
        >
          <img className={styles.image} src={getSrcUser.Avatar(userInfo)} />
          <span className={styles.name}>{userInfo.name}</span>   
        </div>
    );
}

export default VideoUser;
