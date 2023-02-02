import React from 'react';
import images from '../../../Other/DictonaryImage';
import './mainButton.css';
import {useNavigate} from 'react-router-dom';

const MainButton = () => {

    const router = useNavigate();

    return (
        <div className='main-button' onClick={()=> router('/main')}>
            <img className='main-image' src={images.mainSumbol}></img>
            <span className='main-name'>Paradise</span>
        </div>
    );
}

export default MainButton;
