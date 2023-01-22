import React, { useState } from 'react';
import './buttonSubscrib.css';

const ButtonSubscrib = () => {

    const[isSub,setIsSub] = useState(false);
    
    const content = !isSub ?"Подписаться":"Отписаться";

    const styleName = !isSub? "btn btn-not-sub" : "btn btn-sub";

    return (
        <button className = {styleName} onClick={()=> setIsSub(!isSub)}>
            {content}
        </button>
    );
}

export default ButtonSubscrib;
