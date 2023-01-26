import React from 'react';
import ControlPanel from './ModalControl/ControlPanel/ControlPanel';
import styles from './modalVideo.module.css'
import ModalVideoContent from './ModalVideoContent/ModalVideoContent';

const ModalVideo = () => {
    return (
        <div className={styles.box}>
            <div className={styles.window}>
                <ControlPanel/>
                <ModalVideoContent/>
            
            </div>
        </div>
    );
}

export default ModalVideo;
