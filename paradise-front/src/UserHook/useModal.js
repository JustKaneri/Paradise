import { useState } from 'react'

const useModal = () => {
    const [modal, setModal] = useState({
        icon:'',
        article:'',
        text:'',
        isShow:false
    });

    const[handler,setHandler] = useState(null);

    function closeModal(handler) {
        setModal(modal =>({...modal, isShow:false}));
        if(handler)
            handler();
    }

    function showModal(icon,article,text){
        setModal(modal =>({...modal, icon:icon,article:article,text:text,isShow:true}));
    }

    return [
        modal,
        closeModal,
        showModal,
        setHandler
    ];
}

export default useModal;