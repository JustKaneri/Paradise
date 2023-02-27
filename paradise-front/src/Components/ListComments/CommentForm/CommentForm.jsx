import React from 'react';
import { useRef } from 'react';
import { useEffect } from 'react';
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
        "createdDate": ""
    });

    const [fetch, isLoading, error] = useFetching(async() =>{
        const responce = await CommentServis.createComment(comment,useTokenHook.getAccsesToken());

        updateComments();

        setComment(comment => ({...comment, createdDate: ""}));
        inputRef.current.value = "";
    });

    const sendComment = ()=>{
        setComment(comment => ({...comment, createdDate: new Date()}))
    }

    useRefreshToken(fetch,error);

    useEffect(()=>{
        if(comment.createdDate == '')
            return;

        fetch();
    },[comment])


    useEffect(()=>{

        if(error.message)
        {
            setComment(comment => ({...comment, createdDate: ""}));
        }

    },[error.message])

    
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
