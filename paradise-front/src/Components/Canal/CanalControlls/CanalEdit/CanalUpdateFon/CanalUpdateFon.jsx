import React,{ useEffect , useState,useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { useFetching } from '../../../../../UserHook/useFeatching';
import useTokenHook from '../../../../../UserHook/useTokensHoouk';
import ProfileServis from '../../../../../Api/ProfileServis/ProfileServis';
import useRefreshToken from '../../../../../UserHook/useRefreshToken';


const CanalUpdateFon = (props) => {
    const refInput = useRef();
    const [fon,setFon] = useState();
    const router = useNavigate();

    const[fetchFon,isLoadingFon,errorFon] = useFetching(async()=>{
        const responce = await ProfileServis.updateFon(fon,useTokenHook.getAccsesToken());

        setFon(null);
        router(0);
    });

    const onChangeFile = (event) => {
        event.stopPropagation();
        event.preventDefault();
        var file = event.target.files[0];

        setFon(file);
    }

    useEffect(()=>{
        if(fon){
            fetchFon();
        }
    },[fon])

    useRefreshToken(fetchFon,fetchFon);

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
                Загрузить фон
            </button>   
        </>
    );
}

export default CanalUpdateFon;
