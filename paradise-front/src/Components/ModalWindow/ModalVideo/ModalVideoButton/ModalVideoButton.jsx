import React from 'react';
import styles from './modalVideoButton.module.css'

const ModalVideoButton = ({children,handler}) => {
    return (
        <>
          <button 
            className={styles.button}
            onClick = {() => handler()}
          >
            {children}
          </button>  
        </>
    );
}

export default ModalVideoButton;
