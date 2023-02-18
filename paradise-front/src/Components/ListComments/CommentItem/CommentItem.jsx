import React from 'react';
import styles from './commentIte.module.css'
import getSrcUser from '../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';

const CommentItem = ({comment}) => {

    const router = useNavigate();

    return (
        <div className={styles.box}>
            <img
                onClick={()=> router(`/profile/${comment.user.id}`)}
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
