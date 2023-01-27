import React from 'react';
import { useState } from 'react';
import { useRef } from 'react';
import ModalVideoButton from '../../ModalVideoButton/ModalVideoButton';
import styles from './contentFile.module.css';

const ContentFile = () => {

    const inputFile = useRef(null); 
    const inputFileVideo = useRef(null);
    const poster =useRef(null);
    const [files,setFiles] = useState({
        pathVideo:null,
        pathPoster:null
    })


    const selectImage = () =>{
        inputFile.current.click();
    }

    const selectVideo = () =>{
        inputFileVideo.current.click();
    }

    const onChangeFile= (event,type) => {
        event.stopPropagation();
        event.preventDefault();
        var file = event.target.files[0];
       
        if(type="img")
            setFiles({...files,pathPoster:inputFile.current.files[0]});
        else
            setFiles({...files,pathVideo:inputFileVideo.current.files[0]});
    }

    const getUrl = (file,element) => {

        if(file === null)
            return '';

        console.log(element);

        let src = '';

        var fr = new FileReader();
        fr.onload = function () {
           element.current.src = fr.result;
        }

        fr.readAsDataURL(file);
    }

    return (
        <div className={styles.box}>
            <input ref={inputFile} id="file-input" 
                   type='file'
                   name="file"
                   accept='.jpg, .jpeg, .png'
                   multiple
                   style={{display: 'none'}}
                   onChange={(event) => onChangeFile(event,'img')}
                   />
            <input ref={inputFileVideo} id="file-input" 
                   type='file'
                   name="file"
                   accept='.mp4'
                   multiple
                   style={{display: 'none'}}
                   onChange={(event) => onChangeFile(event,'video')}
                   />
            <div className={styles.box_block}>
                <span className={styles.article}>Видео:</span>
                <video src={files.pathVideo} className={styles.video}/>
                <ModalVideoButton handler={selectVideo}>
                    Выбрать
                </ModalVideoButton>
            </div>
            <div className={styles.box_block}>
                <span className={styles.article}>Обложка:</span>
                <img 
                    ref={poster}
                    src={getUrl(files.pathPoster,poster)}
                    className={styles.image}
                />
                <ModalVideoButton handler={selectImage}>
                    Выбрать
                </ModalVideoButton>
            </div>
        </div>
    );
}

export default ContentFile;
