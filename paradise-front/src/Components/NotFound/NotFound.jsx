import React from 'react';
import styles from './notFound.module.css';
import { useNavigate } from 'react-router-dom';

const NotFound = () => {

    const router = useNavigate();

    return (
        <div className={styles.box}>
            <span className={styles.article}>
                <b className={styles.code}>
                    404
                </b> 
                Not found
            </span>
            <button 
                onClick={()=> router('/main')}
                className={styles.button}>
                На главную
            </button>
        </div>
    );
}

export default NotFound;
