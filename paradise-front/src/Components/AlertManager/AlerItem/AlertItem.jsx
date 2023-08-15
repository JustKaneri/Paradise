import React, { useEffect, useState } from 'react';
import styles from './alertItem.css';

const AlertItem = (props) => {

    const content = props.content;
    const [style,setStyle] = useState(props.type);
    const time = props.time;
    
    useEffect(()=>{
        setTimeout(()=>{
            //setStyle(style + " remove");
        },time)
    },[])

    return (
        <div className={`alert ${style} `}>
            <div className={`alert-icon icon-${props.type}`}>

            </div>
            <span className='alert-content'>
                {content}
            </span>
        </div>
    );
}

export default AlertItem;
