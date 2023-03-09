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

const VideoAddPage = () => {

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
        const responceCreator = await VideoCreatorServis.createVideo(video,useTokenHook.getAccsesToken());

        const responceVideo = await VideoCreatorServis.uploadVideo(responceCreator.data.id, files.video,useTokenHook.getAccsesToken());

        if(files.poster){
            const responcePoster = await VideoCreatorServis.uploadPoster(responceCreator.data.id, files.poster,useTokenHook.getAccsesToken());
        }

        setHandler(()=> {router('/my-profile')});
        showModal(images.ok,'Успешно','Видео загружено');
    });

    useRefreshToken(fetch,error);

    const createVideo = ()=>{
        if(video.name == '' || video.discript == '')
        {
            showModal(images.error,'Упссс...','Заполните все поля');
        }

        if(files.video){
           // console.log(files.video)
            fetch();
        }
         

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
            <CreatorVideoContent
                setVideoData = {setVideoData}
                video = {video}
                files = {files}
                setFiles = {setFiles}
            />
            <div style={{width:'100vw',display:'flex',justifyContent:'center'}}>
                <CreatorVideoButton
                    handler={()=> createVideo()}
                >
                    Загрузить видео
                </CreatorVideoButton>
            </div>
        </div>
    );
}

export default VideoAddPage;
