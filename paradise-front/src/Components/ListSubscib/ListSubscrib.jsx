import React from 'react';
import './listSubscrib.css'
import SubscribItem from './SubscibItem/SubscribItem';

const ListSubscrib = ({subscribs}) => {

    return (
        <div className='list-sub'>
            {subscribs.map((sub)=>
                <SubscribItem
                    key={sub.id}
                    subscrib = {sub}
                ></SubscribItem>
            )}
        </div>
    );
}

export default ListSubscrib;
