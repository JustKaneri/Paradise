import React from 'react';
import images from '../../../Other/DictonaryImage';
import './profile.css'

const Profile = () => {
    return (
        <div className='profile'>
            <img className='profile-img' src={images.mainProfile}></img>
        </div>
    );
}

export default Profile;
