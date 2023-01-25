import React from 'react';
import ControlPanel from './ModalControl/ControlPanel/ControlPanel';
import styles from './modalVideo.module.css'

const ModalVideo = () => {
    return (
        <div className={styles.box}>
            <div className={styles.window}>
                <ControlPanel/>
                
            </div>
        </div>
    );
}

export default ModalVideo;
