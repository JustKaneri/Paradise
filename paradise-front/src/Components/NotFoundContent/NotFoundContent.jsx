import React from 'react';
import images from '../../Other/DictonaryImage';
import styles from './notFoundContent.module.css';

const NotFoundContent = () => {
    return (
        <div className={styles.box}>
            <img 
                className={styles.image}
                src={images.notFound}/>
            <span className={styles.text}>Увы, но здесь пока ничего нет</span>
        </div>
    );
}

export default NotFoundContent;
