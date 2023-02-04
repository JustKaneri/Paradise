import React from 'react';
import VideoItem from './VideoItem/VideoItem';
import './listVideo.css'

const ListVideo = ({videos}) => {

    return (
        <div className='list-video'>
            {videos.map((value)=>
                <VideoItem
                     key={value.id}
                     videoItem = {value}
                ></VideoItem>)
            }
        </div>
    );
}

export default ListVideo;
