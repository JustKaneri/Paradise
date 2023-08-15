import { useContext } from "react";
import { AuthContext } from "../Context";

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