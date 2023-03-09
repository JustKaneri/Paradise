import React from 'react';
import { useState } from 'react';
import { useMemo } from 'react';
import { useRef } from 'react';
import InputFileModalVideo from '../../InputFile/InputFileModalVideo';
import CreatorVideoButton from '../../CreatorlVideoButton/CreatorVideoButton';
import styles from './contentFile.module.css';

const ContentFile = ({data,handler}) => {

    const inputFile = useRef(null); 
    const inputFileVideo = useRef(null);
    const poster =useRef(null);
    const video = useRef(null);
    const [files,setFiles] = useState({
        pathVideo:null,
        pathPoster:null
    })

    const renderVideo = useMemo(() => (
        <video
            ref = {video}
            className={styles.video}
            controls
        />
    ), [files.pathVideo]);

    return (
        <div className={styles.box}>
            <InputFileModalVideo
                data = {data}
                handler = {handler}
                reference = {inputFile}
                files ={files}
                setFiles = {setFiles}
                accept = '.jpg, .jpeg, .png'
                type = 'img'
                poster = {poster}
            />
            <InputFileModalVideo
                data = {data}
                handler = {handler}
                reference = {inputFileVideo}
                files = {files}
                setFiles = {setFiles}
                accept = '.mp4'
                type = 'video'
                video = {video}
            />
            <div className={styles.box_block}>
                <span className={styles.article_video}>Видео</span>
                {renderVideo}
                <CreatorVideoButton 
                    handler={() => inputFileVideo.current.click()}>
                    Выбрать
                </CreatorVideoButton>
            </div>
            <div className={styles.box_block}>
                <span className={styles.article_poster}> Обложка</span>
                <img 
                    ref={poster}
                    className={styles.image}
                />
                <CreatorVideoButton 
                    handler={() => inputFile.current.click()}>
                    Выбрать
                </CreatorVideoButton>
            </div>
        </div>
    );
}

export default ContentFile;
