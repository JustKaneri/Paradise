import React from 'react';
import ProfileVideoItem from './ProfileVideoItem/ProfileVideoItem';
import styles from './profileVideoList.module.css'

const ProfileVideoList = ({video}) => {

    return (
        <div className={styles.box}>
            {video.map((value,index)=>
                <ProfileVideoItem
                    item={value}
                    index = {index+1}
                />
            )}        
        </div>
    );
}

export default ProfileVideoList;
