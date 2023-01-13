import React, { useState } from 'react';
import './buttonSubscrib.css';

const ButtonSubscrib = () => {

    const[isSub,setIsSub] = useState(false);
    console.log(isSub);

    const content = !isSub ?"Подписаться":"Отписаться";

    const styleName = !isSub? "btn btn-not-sub" : "btn btn-sub";

    return (
        <button className = {styleName}>
            {content}
        </button>
    );
}

export default ButtonSubscrib;
