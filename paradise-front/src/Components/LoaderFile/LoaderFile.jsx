import React from 'react';
import styles from './loaderFile.module.css'

const LoaderFile = ({value}) => {
    return (
        <div className={styles.box}>
            <div className={styles.card}>
                <h2 className={styles.title} >Загрузка</h2>
                <p className={styles.content} >Загружено {value}%</p>
                <div className={styles.loader}>
                    <div className={styles.spin}></div>
                    <div className={styles.bonus}></div>
                </div>
            </div>
        </div>
    );
}

export default LoaderFile;
