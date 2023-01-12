import React from 'react';
import styles from './subscribItem.module.css'

const SubscribItem = ({subscrib}) => {

    console.log(subscrib)

    return (
        <div key={subscrib.id} className={styles.profile}> 
            <img src={subscrib.subscriber.profile.pathAvatar} className={styles.avatar}/>
            <span className={styles.name}> {subscrib.subscriber.name} </span>
        </div>
    );
}

export default SubscribItem;
