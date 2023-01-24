import React from 'react';
import styles from './commentIte.module.css'

const CommentItem = ({comment}) => {
    return (
        <div className={styles.box}>
            <img
                className={styles.avatar} 
                src = {comment.user.profile.pathAvatar}
            />
            <span className={styles.name}>
                {comment.user.name}
            </span>
            <span className={styles.date}>
                {comment.createdDate}
            </span>
            <span className={styles.content}>
                {comment.content}
            </span>
        </div>
    );
}

export default CommentItem;
