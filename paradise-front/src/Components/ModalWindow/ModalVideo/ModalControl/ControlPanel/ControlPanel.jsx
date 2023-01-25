import React from 'react';
import styles from './controlPanel.module.css'

const ControlPanel = () => {
    return (
        <div className={styles.control}>
            <button className={styles.btn_close}>
                X
            </button>
        </div>
    );
}

export default ControlPanel;
