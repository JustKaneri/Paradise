import React, { useState }  from 'react';
import images from '../../../Other/DictonaryImage';
import ModalContentAuth from '../../ModalWindow/ModalList/ListAuth/ModalContentAuth';
import ModalContentNotAuth from '../../ModalWindow/ModalList/ListNotAuth/ModalContentNotAuth';
import ModalMenu from '../../ModalWindow/ModalMenu/ModalMenu';
import './profile.css'

const Profile = () => {

    const[IsVisible,setIsVisible] = useState(false);

    return (
        <div className='profile' onClick={()=> setIsVisible(!IsVisible)}>
            <img className='profile-img' src={images.mainProfile}></img>          
            <ModalMenu 
                IsVisible = {IsVisible}
            > 
                <ModalContentNotAuth/>
            </ModalMenu>
        </div>
    );
}

export default Profile;
