import React from 'react';
import { useNavigate } from 'react-router-dom';
import images from '../../../../Other/DictonaryImage';
import useTokenHook from '../../../../UserHook/useTokensHoouk';
import ModalButton from '../../ModalButton/ModalButton';
import './modalContent.css'

const ModalContentAuth = () => {

    const router = useNavigate();

    const logOut = () =>{
        useTokenHook.resetTokens();
        router(0);
    }


    return (
        <div className = 'content-auth'>
            <ModalButton 
                    srcImage = {images.profile}
                    handler = { () => alert('В разработке') }
                    name = {'Профиль'}
            />
            <ModalButton 
                    srcImage = {images.favorite}
                    handler = { () => alert('В разработке') }
                    name = {'Избранное'}
            />
            <ModalButton 
                    srcImage = {images.addVideo}
                    handler = { () => alert('В разработке') }
                    name = {'Добавить'}
            />
            <ModalButton 
                    srcImage = {images.subscrib}
                    handler = { () => router('/subscribs') }
                    name = {'Подписки'}
            />
            <ModalButton 
                    srcImage = {images.logOut}
                    handler = { () => logOut() }
                    name = {'Выйти'}
            />
        </div>
    );
}

export default ModalContentAuth;
