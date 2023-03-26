import React from 'react';
import VideoRowItem from './VideoRowItem/VideoRowItem'
import styles from './listVideoRow.module.css'

const ListVidoeRow = ({video}) => {

    return (
        <div className={styles.box}>
            {video.map((value,index)=>
                <VideoRowItem
                    value = {value}
                    key = {value.id}
                    index = {index+1}
                />
            )}
        </div>
    );
}

export default ListVidoeRow;
