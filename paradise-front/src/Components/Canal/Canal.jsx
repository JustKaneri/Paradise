import React from 'react';
import ButtonSubscrib from '../ButtonSubscrib/ButtonSubscrib';
import ListVideo from '../ListVideo/ListVideo';
import ProfileCanal from './ProfileCanal/ProfileCanal';

const Canal = () => {
    return (
        <div>
            <ProfileCanal/>
            <ButtonSubscrib/>
            <ListVideo/>
        </div>
    );
}

export default Canal;
