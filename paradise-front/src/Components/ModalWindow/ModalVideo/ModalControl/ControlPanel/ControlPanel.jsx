import React from 'react';
import styles from './controlPanel.module.css'

const ControlPanel = () => {
    return (
        <div className={styles.control}>
            <span className={styles.article}>
                Добавить видео
            </span>
            <button className={styles.btn_close}>
                X
            </button>
        </div>
    );
}

export default ControlPanel;