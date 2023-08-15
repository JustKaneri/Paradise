import { useEffect } from "react";
import useTokenHook from "./useTokensHoouk";
import AuthServis from "../Api/AuthServis/AuthServis";
import { useContext } from "react";
import { AuthContext } from "../Context";
import { useNavigate } from "react-router-dom";
import { useFetching } from "./useFeatching";
import { useMemo } from "react";

const CreateAlert = () =>{

    const {Alert,setAlert} = useContext(AuthContext);

    function showAlert(content,type){
        setAlert(Alert => ({
            ...Alert,
            id: Math.random().toString(16).slice(2),
            content: content,
            type: type
        }));
    }

    return [showAlert];
}

export default CreateAlert;