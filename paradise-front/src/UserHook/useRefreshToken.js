import { useEffect } from "react";
import useTokenHook from "./useTokensHoouk";
import AuthServis from "../Api/AuthServis/AuthServis";
import { useContext } from "react";
import { AuthContext } from "../Context";
import { useNavigate } from "react-router-dom";
import { useFetching } from "./useFeatching";
import { useMemo } from "react";

const useRefreshToken = (handler,error) =>{

    const {IsAuth,setIsAuth} = useContext(AuthContext);
    const {IsUpdate,setIsUpdate} = useContext(AuthContext);
    const router = useNavigate();

    const [fetchUpdate,isLoadingTokens,errorTokens] = useFetching(async () =>{
        let tokens = useTokenHook.getTokens();
        const responce = await AuthServis.updateTokens(tokens);
        useTokenHook.saveTokens(responce.data);
        handler();
        console.log('updateTokens');
    });

    const [fetch] = useFetching(async () =>{
        let tokens = useTokenHook.getTokens();
        const responce = await AuthServis.revokedTokens(tokens);
    });

    useMemo(()=>{
        if(error.response == undefined)
             return;

        //Если запрос возвращает ошибку 401 (проблемы с токеном)
        if(error.response.status == 401){
            //Если токен не находится в процессе обновления
            if(!IsUpdate){
                setIsUpdate(true);
                fetchUpdate();
            }
            else{
               //иначе вызываем запрос повторно
               setTimeout(()=>handler(),150);
            }      
        }
    },[error.message])

    useMemo(()=>{         
        if(errorTokens.message){
            fetch();
            useTokenHook.resetTokens();
            setIsAuth(false);
            router('/login'); 
        }
    },[errorTokens.message])


    return errorTokens;
}

export default useRefreshToken;