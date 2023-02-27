import React from 'react';
import styles from './commentSend.module.css'

const CommentSend = (props) => {
    return (
        <>
          <button {...props} className={styles.btn_send} >
                Отправить
          </button>  
        </>
    );
}

export default CommentSend;
