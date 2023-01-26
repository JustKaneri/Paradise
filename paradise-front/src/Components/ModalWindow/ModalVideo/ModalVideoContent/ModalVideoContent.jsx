import React from 'react';
import { useState } from 'react';
import ContentText from './ContentText/ContentText';
import styles from './modalVideoContent.module.css';

const ModalVideoContent = () => {

    const [newVideo,setNewVideo] = useState({
        "name": '',
  	    "discript": '',
  	    "dateCreate": new Date ()
    });

    return (
        <div className={styles.box}>
            <ContentText 
                video = {newVideo}
                handler = {setNewVideo}
            />
        </div>
    );
}

export default ModalVideoContent;
