import React from 'react';
import styles from './commentIte.module.css'

const CommentItem = ({comment}) => {
    return (
        <div className={styles.box}>
            <img
                className={styles.avatar} 
                src = {comment.user.profile.pathAvatar}/>
        </div>
    );
}

export default CommentItem;
