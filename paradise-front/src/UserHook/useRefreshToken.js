import { useEffect } from "react";
import useTokenHook from "./useTokensHoouk";
import AuthServis from "../Api/AuthServis/AuthServis";
import { useContext } from "react";
import { AuthContext } from "../Context";
import { useNavigate } from "react-router-dom";
import { useFetching } from "./useFeatching";

const useRefreshToken = (handler,error) =>{

    const {IsAuth,setIsAth} = useContext(AuthContext);
    const router = useNavigate();

    const [fetchTokens,isLoadingTokens,errorTokens] = useFetching(async () =>{
        let tokens = useTokenHook.getTokens();
        const responce = await AuthServis.updateTokens(tokens);

        useTokenHook.updateTokens(responce.data);
    });

    useEffect(()=>{
        if(error){
            fetchTokens();
            handler();
        }
    },[error])


    useEffect(()=>{
        
        if(errorTokens){
            console.log(errorTokens);
            useTokenHook.resetTokens();
            setIsAth(false);
            router('/login');
        }
    },[errorTokens])


    return errorTokens;
}

export default useRefreshToken;