import React from 'react';
import styles from './authInput.module.css'

const AuthInput = ({nameLabel,inputName,isPassword,refInput}) => {

    const typeInput = !isPassword ? 'input': 'password';

    return (
        <div className={styles.box}>
            <label 
                className={styles.label}
                htmlFor={inputName}>
                    {nameLabel}:
            </label>
            <input 
                className={styles.input}
                type={typeInput}
                name={inputName} 
                id={inputName}
                ref = {refInput}>    
            </input>
        </div>
    );
}

export default AuthInput;
