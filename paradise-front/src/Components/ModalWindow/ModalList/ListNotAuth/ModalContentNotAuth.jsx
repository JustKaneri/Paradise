import React from 'react';
import images from '../../../../Other/DictonaryImage';
import ModalButton from '../../ModalButton/ModalButton';
import './modalContent.css'
import { useNavigate } from 'react-router-dom';


const ModalContentNotAuth = () => {

    const router = useNavigate();

    return (
        <div className='content'>
             <ModalButton 
                    srcImage = {images.logIn}
                    handler = { () => router('/login') }
                    name = {'Вход'}
                /> 
                <ModalButton 
                    srcImage = {images.regestry}
                    handler = { () => router('/regestry') }
                    name = {'Регистрация'}
                />
        </div>
    );
}

export default ModalContentNotAuth;
