import React from 'react';
import FavoriteItem from './FavoriteItem/FavoriteItem';
import styles from './favoriteList.module.css'

const FavoriteList = ({video}) => {

    return (
        <div className={styles.box}>
            {video.map((value,index)=>
                <FavoriteItem
                    value = {value}
                    key = {value.id}
                    index = {index+1}
                />
            )}
        </div>
    );
}

export default FavoriteList;
