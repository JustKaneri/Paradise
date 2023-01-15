import React from 'react';
import styles from './canalFon.module.css'

const CanalFon = ({src}) => {
    return (
        <img className= {styles.image_fon} 
             src={src}>
        </img>
    );
}

export default CanalFon;
