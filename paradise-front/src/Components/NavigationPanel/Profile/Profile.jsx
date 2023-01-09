import React, { useState }  from 'react';
import images from '../../../Other/DictonaryImage';
import ModalMenu from '../../ModalWindow/ModalMenu/ModalMenu';
import './profile.css'

const Profile = () => {

    const[IsVisible,setIsVisible] = useState(false);

    return (
        <div className='profile' onClick={()=> setIsVisible(!IsVisible)}>
            <img className='profile-img' src={images.mainProfile}></img>          
            <ModalMenu 
                IsVisible = {IsVisible}
            />
        </div>
    );
}

export default Profile;
