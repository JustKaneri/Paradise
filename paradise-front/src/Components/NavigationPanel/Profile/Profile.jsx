import React from 'react';
import './profile.css'

const Profile = () => {
    return (
        <div className='profile'>
            <img className='profile-img' src={require('../../../Assets/Profile.png')}></img>
        </div>
    );
}

export default Profile;
