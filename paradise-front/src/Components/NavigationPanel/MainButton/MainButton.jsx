import React from 'react';
import images from '../../../Other/DictonaryImage';
import './mainButton.css'

const MainButton = () => {
    return (
        <div className='main-button' onClick={()=> alert('MainButton')}>
            <img className='main-image' src={images.mainSumbol}></img>
            <span className='main-name'>Paradise</span>
        </div>
    );
}

export default MainButton;
