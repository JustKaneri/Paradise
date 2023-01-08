import React from 'react';
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
        </div>
    );
}

export default Navigation;
