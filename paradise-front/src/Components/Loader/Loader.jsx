import React from 'react';
import styles from './loader.module.css';

const Loader = () => {
    return (
        <div className={styles.spinner_box}>
            <span className={styles.loading}>Загрузка...</span>
        </div>
    );
}

export default Loader;
