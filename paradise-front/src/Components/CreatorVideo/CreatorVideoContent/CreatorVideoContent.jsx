import React from 'react';
import { useRef } from 'react';
import { useState } from 'react';
import ContentFile from './ContentFile/ContentFile';
import ContentText from './ContentText/ContentText';
import styles from './creatorVideoContent.module.css'

const ModalVideoContent = () => {

    const [newVideo,setNewVideo] = useState({
        "name": '',
  	    "discript": '',
  	    "dateCreate": new Date ()
    });

    const inputName = useRef(null);
    const inputDiscript = useRef(null);

    console.count('Render');

    return (
        <div className={styles.box}>
            <ContentText 
                inputName={inputName}
                inputDisc = {inputDiscript}
            />
            <ContentFile/>
        </div>
    );
}

export default ModalVideoContent;
