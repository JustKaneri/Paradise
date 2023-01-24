import React from 'react';
import styles from './commentSend.module.css'

const CommentSend = () => {
    return (
        <>
          <button className={styles.btn_send} >
                Отправить
          </button>  
        </>
    );
}

export default CommentSend;
