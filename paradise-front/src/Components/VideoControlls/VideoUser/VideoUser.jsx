import React from 'react';
import styles from './videoUser.module.css'
import images from '../../../Other/DictonaryImage';

const VideoUser = ({user}) => {
  
  const getSrcAva = () =>{
    let src = images.profile;

    if(user.profile != null)
      if(user.profile.pathAvatar != null)
        src = user.profile.pathAvatar;

    return src;
  }

    return (
        <div className={styles.box}>
          <img className={styles.image} src={getSrcAva()} />
          <span className={styles.name}>{user.name}</span>   
        </div>
    );
}

export default VideoUser;
