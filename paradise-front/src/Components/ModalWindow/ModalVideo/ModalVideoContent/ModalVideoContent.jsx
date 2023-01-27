import React from 'react';
import { useState } from 'react';
import ContentFile from './ContentFile/ContentFile';
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
            <ContentFile/>
        </div>
    );
}

export default ModalVideoContent;
