import React from 'react';
import ModalButton from '../ModalButton/ModalButton';
import './modalMenu.css'

const ModalMenu = (IsVisible) => {
    return (
        <div className='modal active'>
            <div className='modal-content'>
                <ModalButton 
                    srcImage = {(require("../../../Assets/LogIn.png"))}
                    handler = { () => alert('ok') }
                    name = {'Вход'}
                />
            </div>
        </div>
    );
}

export default ModalMenu;
