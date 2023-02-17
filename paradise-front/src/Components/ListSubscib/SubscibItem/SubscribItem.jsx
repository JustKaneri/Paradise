import React from 'react';
import { useNavigate } from 'react-router-dom';
import useSrcUser from '../../../UserHook/useSrcUser.js';
import styles from './subscribItem.module.css'

const SubscribItem = ({subscrib}) => {

    const router = useNavigate();
    
    return (
        <div key={subscrib.id} onClick={()=> router(`/profile/${subscrib.subscriber.id}`)} className={styles.profile}> 
            <img src={useSrcUser.Avatar(subscrib.subscriber)} className={styles.avatar}/>
            <span className={styles.name}> {subscrib.subscriber.name} </span>
        </div>
    );
}

export default SubscribItem;
