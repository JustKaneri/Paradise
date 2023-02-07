import React from 'react';
import styles from './videoUser.module.css'
import images from '../../../Other/DictonaryImage';

const VideoUser = ({userInfo}) => {


  const getSrcAva = () =>{
    let src = images.profile;

    if(userInfo.profile != null)
      if(userInfo.profile.pathAvatar != null)
        src = userInfo.profile.pathAvatar;

    return src;
  }

    return (
        <div className={styles.box}>
          <img className={styles.image} src={getSrcAva()}  />
          <span className={styles.name}>{userInfo.name}</span>   
        </div>
    );
}

export default VideoUser;
