import React from 'react';
import styles from './creatorVideoButton.module.css'

const ModalVideoButton = (props) => {
    return (
        <>
          <button 
            {...props}
            className={styles.button}
            onClick = {() => props.handler()}
          >
            {props.children}
          </button>  
        </>
    );
}

export default ModalVideoButton;
