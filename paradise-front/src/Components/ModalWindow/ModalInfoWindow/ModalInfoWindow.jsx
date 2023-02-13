import React from 'react';
import styles from './modal.module.css'
import ReactDOM from 'react-dom';

const ModalInfoWindow = () => {
    return ReactDOM.createPortal(
        <div className={styles.box}>
            <div className={styles.window}>
                 <img/>
                 <span>
                    Article text
                 </span>
                 <span>
                    text
                 </span>
                 <button>

                 </button>
            </div>
        </div>, 
        document.body
    );
}

export default ModalInfoWindow;
