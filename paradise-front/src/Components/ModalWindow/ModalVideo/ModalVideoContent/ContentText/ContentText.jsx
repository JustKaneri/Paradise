import React from 'react';
import { useState } from 'react';
import styles from './contentText.module.css'

const ContentText = ({inputName , inputDisc}) => {

    const [lengthInput,setLengthInput] = useState({name:0,disc:0});

    return (
        <div className={styles.box}>
            <div className={styles.box_name}>
                <span className={styles.article}>
                    Название
                </span>
                <textarea
                    ref ={inputName}
                    maxLength='80'
                    className={styles.input}
                    onChange={(event) => setLengthInput({...lengthInput, name: event.target.value.length})}>
                </textarea>
                <span className={styles.counter}>
                    {lengthInput.name} /80
                </span>
            </div>
            <div className={styles.box_discr}>
                <span className={styles.article}>
                   Описание:
                </span>
                <textarea
                    ref = {inputDisc}
                    maxLength='300'
                    className={styles.input}
                    onChange={(event) => setLengthInput({...lengthInput, disc: event.target.value.length})}>
                </textarea>
                <span className={styles.counter}>
                    {lengthInput.disc}  / 300
                </span>
            </div>
        </div>
    );
}

export default ContentText;
