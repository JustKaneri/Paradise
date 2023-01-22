import React, { useState } from 'react';
import styles from './responceLike.module.css'
import images from '../../../../Other/DictonaryImage.js'

const ResponceLike = ({handler,countLike,isLike}) => {

    const srcImg = !isLike ?  images.like : images.likeActive;

    return (
        <div className={styles.box}>
            <span className={styles.counter}>
                {countLike}
            </span>
            <img className={styles.img} 
                 src={srcImg}
                onClick={()=> handler()}
            />
        </div>
    );
}

export default ResponceLike;
