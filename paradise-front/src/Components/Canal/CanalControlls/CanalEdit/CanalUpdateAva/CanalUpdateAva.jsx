import React,{ useEffect , useState,useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { useFetching } from '../../../../../UserHook/useFeatching';
import useTokenHook from '../../../../../UserHook/useTokensHoouk';
import ProfileServis from '../../../../../Api/ProfileServis/ProfileServis';
import useRefreshToken from '../../../../../UserHook/useRefreshToken';

const CanalUpdateAva = (props) => {

    const refInput = useRef();
    const [avatar,setAvatar] = useState();
    const router = useNavigate();

    const[fetchAvatar,isLoadingAvatar,errorAvatar] = useFetching(async()=>{
        const responce = await ProfileServis.updateAvatar(avatar,useTokenHook.getAccsesToken());

        setAvatar(null);
        router(0);
    });

    const onChangeFile = (event,type) => {
        event.stopPropagation();
        event.preventDefault();
        var file = event.target.files[0];

        setAvatar(file);
    }

    useEffect(()=>{
        if(avatar){
            fetchAvatar();
        }
    },[avatar])

    useRefreshToken(fetchAvatar,errorAvatar);

    return (
        <>
            <input
                ref = {refInput} 
                id="file-input" 
                type='file'
                name="file"
                accept= '.jpg, .jpeg, .png'
                multiple
                style={{display: 'none'}}
                onChange={(event) => onChangeFile(event)}
            />
            <button 
                onClick={()=> refInput.current.click()}
                className={props.styles}>
                Загрузить аватар
            </button>
        </>
    );
}

export default CanalUpdateAva;
