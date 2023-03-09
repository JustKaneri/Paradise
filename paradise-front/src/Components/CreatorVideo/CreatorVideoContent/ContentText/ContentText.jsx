import React from 'react';
import { useState } from 'react';
import styles from './contentText.module.css'

const ContentText = ({handler,data}) => {
    return (
        <div className={styles.box}>
            <div className={styles.box_name}>
                <span className={styles.article}>
                    Название
                </span>
                <textarea
                    maxLength='80'
                    className={styles.input}
                    onChange={(event) => handler(data=>({...data,name:event.target.value.trim()}))}>
                </textarea>
                <span className={styles.counter}>
                    {data.name.length} /80
                </span>
            </div>
            <div className={styles.box_discr}>
                <span className={styles.article}>
                   Описание:
                </span>
                <textarea
                    maxLength='300'
                    className={styles.input}
                    onChange={(event) => handler(data=>({...data, discript :event.target.value.trim()}))}>
                </textarea>
                <span className={styles.counter}>
                    {data.discript.length}  / 300
                </span>
            </div>
        </div>
    );
}

export default ContentText;
