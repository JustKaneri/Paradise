import React from 'react';
import ButtonSubscrib from '../ButtonSubscrib/ButtonSubscrib';
import styles from './videoControlls.module.css'
import VideoName from './VideoName/VideoName';
import VideoResponce from './VideoResponce/VideoResponce';
import VideoUser from './VideoUser/VideoUser';

const VideoControlls = ({videoInfo,countResponce}) => {
    
    return (
        <div className={styles.box}>
            <VideoName name={videoInfo.name}/>
            <div className={styles.box_elements}>
                <VideoUser userInfo = {videoInfo.user} />
                <ButtonSubscrib></ButtonSubscrib>
                <VideoResponce 
                    idVideo={videoInfo.id}
                    countResponce={countResponce}/>
            </div>
        </div>
    );
}

export default VideoControlls;
