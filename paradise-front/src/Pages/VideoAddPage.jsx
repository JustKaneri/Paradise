import React from 'react';
import PageName from '../Components/PageName/PageName';
import CreatorVideoContent from '../Components/CreatorVideo/CreatorVideoContent/CreatorVideoContent';
import CreatorVideoButton from '../Components/CreatorVideo/CreatorlVideoButton/CreatorVideoButton'

const VideoAddPage = () => {
    return (
        <div>
            <PageName
                content = {'Добавить видео'}
            />
            <CreatorVideoContent/>
            <div style={{width:'100vw',display:'flex',justifyContent:'center'}}>
                <CreatorVideoButton>
                    Загрузить видео
                </CreatorVideoButton>
            </div>
        </div>
    );
}

export default VideoAddPage;
