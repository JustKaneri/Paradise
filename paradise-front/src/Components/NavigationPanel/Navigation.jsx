import React from 'react';
import ModalMenu from '../ModalWindow/ModalMenu/ModalMenu';
import MainButton from './MainButton/MainButton';
import './navigation.css';
import Profile from './Profile/Profile';
import Search from './Search/Search';

const Navigation = () => {
    return (
        <div className="nav-panel">
            <MainButton></MainButton>
            <Search></Search>
            <Profile/>
            <ModalMenu></ModalMenu>
        </div>
    );
}

export default Navigation;
