import React from 'react';
import styles from './authInput.module.css'

const AuthInput = ({nameLabel,inputName}) => {
    return (
        <div className={styles.box}>
            <label 
                className={styles.label}
                htmlFor={inputName}>
                    {nameLabel}:
            </label>
            <input 
                className={styles.input}
                type="input" 
                name={inputName} 
                id={inputName}>    
            </input>
        </div>
    );
}

export default AuthInput;
