import React from 'react';
import { useRef } from 'react';
import { useState } from 'react';
import ContentFile from './ContentFile/ContentFile';
import ContentText from './ContentText/ContentText';
import styles from './creatorVideoContent.module.css'

const ModalVideoContent = (props) => {

    return (
        <div className={styles.box}>
            <ContentText 
                handler = {props.setVideoData}
                data = {props.video}
            />
            <ContentFile
                handler={props.setFiles}
                data = {props.files}
            />
        </div>
    );
}

export default ModalVideoContent;
