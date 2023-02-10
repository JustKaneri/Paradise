import React from 'react';
import styles from './videoUser.module.css'
import images from '../../../Other/DictonaryImage';
import { useNavigate } from 'react-router-dom';

const VideoUser = ({userInfo}) => {

  const router = useNavigate();

  const getSrcAva = () =>{
    let src = images.profile;

    if(userInfo.profile != null)
      if(userInfo.profile.pathAvatar != null)
        src = userInfo.profile.pathAvatar;

    return src;
  }

    return (
        <div className={styles.box}
             onClick={()=> router(`/profile/${userInfo.id}`)}
        >
          <img className={styles.image} src={getSrcAva()}  />
          <span className={styles.name}>{userInfo.name}</span>   
        </div>
    );
}

export default VideoUser;
