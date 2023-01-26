import React from 'react';
import styles from './contentText.module.css'

const ContentText = ({video , handler}) => {

    const changeName = (event) =>{
        handler({...video, name: event.target.value});
    }

    const changeDiscrip = (event) =>{
        handler({...video, discript: event.target.value});
    }

    return (
        <div className={styles.box}>
            <div className={styles.box_name}>
                <span className={styles.article}>
                    Название
                </span>
                <textarea
                    maxLength='80'
                    onChange={(event) => changeName(event)}
                    className={styles.input}>
                </textarea>
                <span className={styles.counter}>
                    {video.name.length} / 80
                </span>
            </div>
            <div className={styles.box_discr}>
                <span className={styles.article}>
                   Описание:
                </span>
                <textarea
                    maxLength='300'
                    onChange={(event) => changeDiscrip(event)} 
                    className={styles.input}>
                </textarea>
                <span className={styles.counter}>
                    {video.discript.length} / 300
                </span>
            </div>
        </div>
    );
}

export default ContentText;
