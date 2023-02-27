import React from 'react';
import { useContext } from 'react';
import { AuthContext } from '../../Context';
import CommentForm from './CommentForm/CommentForm';
import CommentItem from './CommentItem/CommentItem';
import styles from './listComments.module.css'

const ListComments = ({comments,id,handler}) => {

    const {IsAuth} = useContext(AuthContext);
    
    return (
        <div className={styles.box}>
            <h2 className={styles.article}>
              Коментариев {comments.length}
            </h2>
            {IsAuth &&
                <CommentForm
                    id = {id}
                    updateComments = {handler}
                />
            }
            {comments.map(value => 
                <CommentItem 
                    key={value.id} 
                    comment = {value}
                />
            )}
        </div>
    );
}

export default ListComments;
