import React from 'react';
import images from '../../../Other/DictonaryImage';
import ModalButton from '../ModalButton/ModalButton';
import './modalMenu.css'

const ModalMenu = ({IsVisible}) => {

    let styles = 'modal';
    
    if(IsVisible)
        styles += ' active';

    return (
        <div className={styles}>
            <div className='modal-content'>
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
                <span className='content-autor'>© 2022 Cradle of Desires</span>
            </div>
        </div>
    );
}

export default ModalMenu;
