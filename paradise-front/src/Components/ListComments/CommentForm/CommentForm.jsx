import React from 'react';
import { useRef } from 'react';
import { useState } from 'react';
import CommentServis from '../../../Api/CommentsServis/CommentServis';
import { useFetching } from '../../../UserHook/useFeatching';
import useRefreshToken from '../../../UserHook/useRefreshToken';
import useTokenHook from '../../../UserHook/useTokensHoouk';
import styles from './commentForm.module.css'
import CommentSend from './CommentSend/CommentSend';

const CommentForm = ({id,updateComments}) => {

    const inputRef = useRef(null);
    const [comment,setComment] = useState({
        "videoId": id,
        "content": "",
    });

    const [fetch, isLoading, error] = useFetching(async() =>{
        const responce = await CommentServis.createComment(comment,useTokenHook.getAccsesToken());

        updateComments();

        inputRef.current.value = "";
    });

    const sendComment = ()=>{
        if(comment.content != '')
            fetch();
    }

    useRefreshToken(fetch,error);
    
    return (
        <div className={styles.box}>
            <textarea
                ref={inputRef}
                className={styles.input}
                maxLength={300}
                onChange={(event)=> setComment(comment => ({...comment, content: event.target.value}))}
            ></textarea>
            <span className={styles.counter}>
                {comment.content.length}/300
            </span>
            <CommentSend
                onClick = {()=> sendComment()}
            />
        </div>
    );
}

export default CommentForm;
