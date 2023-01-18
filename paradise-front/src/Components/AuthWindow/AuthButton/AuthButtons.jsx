import React from 'react';
import AuthMainButton from './AuthMainButton/AuthMainButton';

const AuthButtons = ({status}) => {
    return (
        <div>
            <AuthMainButton 
                status = {status}
            />
        </div>
    );
}

export default AuthButtons;
