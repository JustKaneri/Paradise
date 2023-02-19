import React from 'react';
import { useState } from 'react';
import styles from './commentForm.module.css'
import CommentSend from './CommentSend/CommentSend';

const CommentForm = () => {

    const [string,setString] = useState('');
    
    return (
        <div className={styles.box}>
            <textarea
                className={styles.input}
                maxLength={300}
                onChange={(event)=> setString(event.target.value)}
            ></textarea>
            <span className={styles.counter}>
                {string.length}/300
            </span>
            <CommentSend/>
        </div>
    );
}

export default CommentForm;
