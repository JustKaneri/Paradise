import React from 'react';
import styles from './modal.module.css'
import ReactDOM from 'react-dom';

const ModalInfoWindow = (props) => {
    if (!props.modal.isShow) {
        return null;
    }
    
    return ReactDOM.createPortal(
        <div className={styles.box}>
            <div className={styles.window}>
                 <img
                    className={styles.image}  
                    src = {props.modal.icon}/>
                 <h2 className={styles.article}>
                    {props.modal.article}
                 </h2>
                 <span className={styles.text}>
                    {props.modal.text}
                 </span>
                 <button 
                    className={styles.button}
                    onClick={()=> props.handler()}>
                    Ok
                 </button>
            </div>
        </div>, 
        document.body
    );
}

export default ModalInfoWindow;
