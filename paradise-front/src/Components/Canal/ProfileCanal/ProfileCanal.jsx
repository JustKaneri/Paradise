import React from 'react';
import ButtonSubscrib from '../../ButtonSubscrib/ButtonSubscrib';
import CanalAvatar from '../ProfileAvatar/CanalAvatar';
import CanalFon from '../ProfileFon/CanalFon';
import ProfileInfo from '../ProfileInfo/ProfileInfo';
import styles from './profileCanal.module.css'

const ProfileCanal = () => {
    return (
        <div className={styles.box}>
            <div className={styles.profile}>
                <CanalFon
                    src={'https://images.hdqwalls.com/download/rising-dragon-0y-3840x2400.jpg'}
                />
                <CanalAvatar
                    src={'https://i.artfile.ru/1920x1380_983550_[www.ArtFile.ru].jpg'}
                />
                <ProfileInfo/>
            </div>
            <ButtonSubscrib/>
        </div>
    );
}

export default ProfileCanal;
