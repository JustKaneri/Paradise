import React from 'react';
import styles from './mainButton.css'

const MainButton = () => {
    return (
        <div className='main-button' onClick={()=> alert('MainButton')}>
            <img className='main-image' src={require('../../../Assets/MainSumbol.png')}></img>
            <span className='main-name'>Paradise</span>
        </div>
    );
}

export default MainButton;
