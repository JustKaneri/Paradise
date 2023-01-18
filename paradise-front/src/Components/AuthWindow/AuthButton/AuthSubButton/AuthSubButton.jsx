import React from 'react';
import '../authButton.css';

const AuthSubButton = ({status,handler}) => {

    const content = status === "reg" ? "Вход": "Регистрация";

    return (
        <button className='auth_button button_small'
                onClick={()=> handler}>
            {content}
        </button>
    );
}

export default AuthSubButton;
