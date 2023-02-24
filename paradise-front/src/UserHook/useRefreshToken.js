import { useEffect } from "react";
import useTokenHook from "./useTokensHoouk";
import AuthServis from "../Api/AuthServis/AuthServis";
import { useContext } from "react";
import { AuthContext } from "../Context";
import { useNavigate } from "react-router-dom";
import { useFetching } from "./useFeatching";

const useRefreshToken = (handler,error) =>{

    const {IsAuth,setIsAuth} = useContext(AuthContext);
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

    useEffect(()=>{
        if(error.response == undefined)
             return;

        if(error.response.status == 401){
            fetchUpdate();
        }
    },[error.message])

    useEffect(()=>{         
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