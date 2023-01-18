import React from 'react';
import '../authButton.css';

const AuthMainButton = ({status,handler}) => {

    const content = status === "reg" ? "Зарегистрироваться": "Вход";
    
    return (
        <button className='auth_button button_big'
                onClick={()=> handler}>
            {content}
        </button>
    );
}

export default AuthMainButton;
