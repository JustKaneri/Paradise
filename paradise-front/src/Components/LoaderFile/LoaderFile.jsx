import React from 'react';
import styles from './loaderFile.module.css'

const LoaderFile = ({value}) => {
    return (
        <div className={styles.box}>
            <div className={styles.card}>
                <h2 className={styles.title} >Загрузка</h2>
                <p>Загружено {value}%</p>
            </div>
        </div>
    );
}

export default LoaderFile;
