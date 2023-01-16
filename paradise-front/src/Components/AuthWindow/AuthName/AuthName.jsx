import React from 'react';
import styles from './authName.module.css'

const AuthName = ({name}) => {
    return (
        <>
           <h2 className={styles.name}>{name}</h2> 
        </>
    );
}

export default AuthName;
