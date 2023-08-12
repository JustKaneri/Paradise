import React from 'react';
import styles from './alertItem.css';

const AlertItem = (props) => {

    const content = props.content;
    const style = props.type;

    return (
        <div className={`alert ${style} `}>
            <div className={`alert-icon icon-${style}`}>

            </div>
            <span className='alert-content'>
                {content}
            </span>
        </div>
    );
}

export default AlertItem;
