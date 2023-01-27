import React from 'react';
import ControlPanel from './ModalControl/ControlPanel/ControlPanel';
import styles from './modalVideo.module.css'
import ModalVideoButton from './ModalVideoButton/ModalVideoButton';
import ModalVideoContent from './ModalVideoContent/ModalVideoContent';

const ModalVideo = () => {
    return (
        <div className={styles.box}>
            <div className={styles.window}>
                <ControlPanel/>
                <ModalVideoContent/>
                <ModalVideoButton>
                    Добавить
                </ModalVideoButton>
            </div>
        </div>
    );
}

export default ModalVideo;
