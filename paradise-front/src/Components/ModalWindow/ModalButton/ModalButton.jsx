import React from 'react';
import './modalButtom.css'

const ModalButton = ({srcImage,handler,name}) => {
    return (
        <div className='modal-button' onClick={()=> handler()}>
            <img className='button-image' src={srcImage}></img>
            <span className='button-name'>{name}</span>
        </div>
    );
}

export default ModalButton;
