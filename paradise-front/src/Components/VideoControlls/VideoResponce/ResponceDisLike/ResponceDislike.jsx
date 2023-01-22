import React, { useState } from 'react';
import images from '../../../../Other/DictonaryImage';
import styles from './responceDislike.module.css'

const ResponceDislike = ({handler,countDis,isDis}) => {

    const srcImg = !isDis ?  images.dislike : images.dislikeActive;
    
    return (
        <div className={styles.box}>
            <img className={styles.img} 
                 src={srcImg}
                onClick={()=> handler()}
            />
            <span className={styles.counter}>
                {countDis}
            </span>  
        </div>
    );
}

export default ResponceDislike;
