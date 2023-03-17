import React from 'react';
import styles from './commentIte.module.css'
import getSrcUser from '../../../UserHook/useSrcUser';
import { useNavigate } from 'react-router-dom';
import Redirect from '../../../UserHook/useRederect';
import { getShortDate, getTime } from '../../../Other/dateFormater';

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
            <div className={styles.box_content}>
                <div className={styles.box_user}>
                    <span className={styles.name}>
                        {comment.user.name}
                    </span>
                    <span className={styles.date}>
                        {getShortDate(comment.createdDate) + ' ' + getTime(comment.createdDate)}
                    </span>
                </div>
                <span className={styles.content}>
                    {comment.content}
                </span>
            </div>
        </div>
    );
}

export default CommentItem;
