import React from 'react';
import ButtonSubscrib from '../../ButtonSubscrib/ButtonSubscrib';
import ProfileInfo from '../ProfileInfo/ProfileInfo';
import styles from './profileCanal.module.css'

const ProfileCanal = () => {
    return (
        <div className={styles.box}>
            <div className={styles.profile}>
                <img className= {styles.image_fon} src='https://images.hdqwalls.com/download/rising-dragon-0y-3840x2400.jpg' />
                <img></img>
                <ProfileInfo/>
            </div>
            <ButtonSubscrib/>
        </div>
    );
}

export default ProfileCanal;
