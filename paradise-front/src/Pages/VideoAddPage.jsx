import React,{useState} from 'react';
import PageName from '../Components/PageName/PageName';
import CreatorVideoContent from '../Components/CreatorVideo/CreatorVideoContent/CreatorVideoContent';
import CreatorVideoButton from '../Components/CreatorVideo/CreatorlVideoButton/CreatorVideoButton'
import useTokenHook from '../UserHook/useTokensHoouk';
import {useFetching} from '../UserHook/useFeatching';
import VideoCreatorServis from '../Api/VideoCreatorServis/VideoCreatorServis';
import { useNavigate } from 'react-router-dom';
import useRefreshToken from '../UserHook/useRefreshToken';
import useModal from '../UserHook/useModal';
import images from '../Other/DictonaryImage';
import ModalInfoWindow from '../Components/ModalWindow/ModalInfoWindow/ModalInfoWindow';
import LoaderFile from '../Components/LoaderFile/LoaderFile';

const VideoAddPage = () => {

    const [load,setLoad] = useState(0);
    const [video,setVideoData] = useState({
        "name": '',
        "discript": ''
    });

    const[modal,closeModal,showModal,setHandler] = useModal();
    const [files,setFiles] = useState({
        video:'',
        poster:''
    });

    const router = useNavigate();

    const [fetch,isLoading,error] = useFetching(async () =>{
        showModal(images.load,'Загрузка','Не закрывайте эту страницу до появления сообщения об окончании загрузки.');
        const responceCreator = await VideoCreatorServis.createVideo(video,files,useTokenHook.getAccsesToken(),setLoad);

        if(responceCreator.data)
            showModal(images.ok,'Успешно','Видео загружено',handler);

        setLoad(0);
    });

    useRefreshToken(fetch,error);

    const createVideo = ()=>{
        if(video.name == '' || video.discript == '')
        {
            showModal(images.error,'Упссс...','Заполните все поля');
        }

        if(files.video){
            fetch();
        }
    }

    const handler = () =>{
        router('/my-profile');
    }

    return (
        <div>
            <ModalInfoWindow
                modal = {modal}
                handler = {closeModal}
            />
            <PageName
                content = {'Добавить видео'}
            />
            {!isLoading &&
                <LoaderFile
                    value={load}
                />
            }
            {isLoading &&
                <>
                    <CreatorVideoContent
                        setVideoData = {setVideoData}
                        video = {video}
                        files = {files}
                        setFiles = {setFiles}
                    />
                    <div style={{width:'100vw',display:'flex',justifyContent:'center'}}>
                        <CreatorVideoButton
                            disabled={isLoading ? true : false}
                            handler={()=> createVideo()}
                        >
                            Загрузить видео
                        </CreatorVideoButton>
                    </div>
                </>
            }
        </div>
    );
}

export default VideoAddPage;
