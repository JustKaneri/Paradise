import React from 'react';
import Player from 'react-custom-player';
import DiscriptVideo from '../DiscriptVideo/DiscriptVideo';
import VideoControlls from '../VideoControlls/VideoControlls';
import styles from './video.module.css';

const Video = ({video}) => {

    console.log(video);

    const videoPlayer = {
        src: video.pathVideo,
        poster:video.pathPoster
    }

    return (
        <div className={styles.box}>
            <div className={styles.video}>
                <Player  video={videoPlayer}/>
            </div>
            <DiscriptVideo
                content = {video.discript}
            />
            <VideoControlls 
                videoInfo = {video}
            />
        </div>
    );
}

export default Video;
