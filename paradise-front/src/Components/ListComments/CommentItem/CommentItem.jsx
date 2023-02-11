import React from 'react';
import styles from './commentIte.module.css'
import getSrcUser from '../../../UserHook/useSrcUser';

const CommentItem = ({comment}) => {
    return (
        <div className={styles.box}>
            <img
                className={styles.avatar} 
                src = {getSrcUser.Avatar(comment.user)}
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
