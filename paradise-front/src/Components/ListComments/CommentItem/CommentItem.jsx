import React from 'react';
import styles from './commentIte.module.css'
import getSrcUser from '../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';
import Redirect from '../../../UserHook/useRederect';

const CommentItem = ({comment}) => {

    const router = useNavigate();
    const [redirect] = Redirect(comment.user.id);

    const toProfile= ()=>{

        if(redirect())
            return;

        router(`/profile/${comment.user.id}`);  
    }

    return (
        <div className={styles.box}>
            <img
                onClick={()=> toProfile()}
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
