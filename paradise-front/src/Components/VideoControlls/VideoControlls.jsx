import React from 'react';
import ButtonSubscrib from '../ButtonSubscrib/ButtonSubscrib';
import styles from './videoControlls.module.css'
import VideoName from './VideoName/VideoName';

const VideoControlls = () => {

    const name = "Wdadawdjhwdkahjdjkawjhkdhwadja daw dwa dawd daw a dw dada d daw da 1 rf czkjhk czxnm ewqe #1";

    return (
        <div className={styles.box}>
            <VideoName name={name}/>
            <div className={styles.box_elements}>
                <ButtonSubscrib></ButtonSubscrib>
            </div>
        </div>
    );
}

export default VideoControlls;
