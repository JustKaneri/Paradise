import React from 'react';
import AuthWindow from '../Components/AuthWindow/AuthWindow';

const AuthPage = () => {
    return (
        <div>
            <AuthWindow
                type = {'login'}
            />
        </div>
    );
}

export default AuthPage;
