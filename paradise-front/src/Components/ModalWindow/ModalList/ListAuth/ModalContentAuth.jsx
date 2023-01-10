import React from 'react';
import images from '../../../../Other/DictonaryImage';
import ModalButton from '../../ModalButton/ModalButton';
import './modalContent.css'

const ModalContentAuth = () => {
    return (
        <div className = 'content-auth'>
            <ModalButton 
                    srcImage = {images.profile}
                    handler = { () => alert('ok') }
                    name = {'Профиль'}
            />
            <ModalButton 
                    srcImage = {images.favorite}
                    handler = { () => alert('ok') }
                    name = {'Избранное'}
            />
            <ModalButton 
                    srcImage = {images.addVideo}
                    handler = { () => alert('ok') }
                    name = {'Добавить'}
            />
            <ModalButton 
                    srcImage = {images.subscrib}
                    handler = { () => alert('ok') }
                    name = {'Подписки'}
            />
            <ModalButton 
                    srcImage = {images.logOut}
                    handler = { () => alert('ok') }
                    name = {'Выйти'}
            />
        </div>
    );
}

export default ModalContentAuth;
