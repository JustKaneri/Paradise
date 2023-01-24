import React from 'react';
import DiscriptVideo from '../Components/DiscriptVideo/DiscriptVideo';
import ListComments from '../Components/ListComments/ListComments';
import Video from '../Components/Video/Video';


const WatchVideoPage = () => {

    const video = {
        src: 'https://localhost:7077/videos/1682f9c30-03a8-48e6-b850-64a010c273d520221202192821529.mp4',
        poster:''
    }
    
    return (
        <div>
            <Video 
                video = {video}
            />
            <ListComments/>
        </div>
    );
}

export default WatchVideoPage;
