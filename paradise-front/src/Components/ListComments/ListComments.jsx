import React from 'react';
import CommentForm from './CommentForm/CommentForm';
import CommentItem from './CommentItem/CommentItem';
import styles from './listComments.module.css'

const ListComments = ({comments}) => {
    
    return (
        <div className={styles.box}>
            <h2 className={styles.article}>
              Коментариев {comments.length}
            </h2>
            <CommentForm/>
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
