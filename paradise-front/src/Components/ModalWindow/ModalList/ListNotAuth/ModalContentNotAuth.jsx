import React from 'react';
import images from '../../../../Other/DictonaryImage';
import ModalButton from '../../ModalButton/ModalButton';
import './modalContent.css'

const ModalContentNotAuth = () => {
    return (
        <div className='content'>
             <ModalButton 
                    srcImage = {images.logIn}
                    handler = { () => alert('ok') }
                    name = {'Вход'}
                /> 
                <ModalButton 
                    srcImage = {images.regestry}
                    handler = { () => alert('ok') }
                    name = {'Регистрация'}
                />
        </div>
    );
}

export default ModalContentNotAuth;
