import React, { useContext } from 'react';
import ButtonSubscrib from '../ButtonSubscrib/ButtonSubscrib';
import styles from './videoControlls.module.css'
import VideoName from './VideoName/VideoName';
import VideoResponce from './VideoResponce/VideoResponce';
import VideoUser from './VideoUser/VideoUser';
import {AuthContext} from '../../Context'
import VideoInfo from './VideoInfo/VideoInfo';

const VideoControlls = ({videoInfo,countResponce}) => {
    
    return (
        <div className={styles.box}>
            <VideoInfo
                info = {videoInfo}
            />
            <VideoName name={videoInfo.name}/>
            <div className={styles.box_elements}>
                <VideoUser userInfo = {videoInfo.user} />
                <ButtonSubscrib
                    id = {videoInfo.user.id}
                />
                <VideoResponce 
                    idVideo={videoInfo.id}
                    countResponce={countResponce}/>
            </div>
            
        </div>
    );
}

export default VideoControlls;
