import { useState } from 'react'

const useModal = () => {
    const [modal, setModal] = useState({
        icon:'',
        article:'',
        text:'',
        isShow:false
    });

    const[handler,setHandler] = useState();

    function closeModal() {
        setModal(modal =>({...modal, isShow:false}));

        if(handler){
            console.log('close add ')
            handler();
        }    
    }

    function showModal(icon,article,text,beforeClose){
        setModal(modal =>({...modal, icon:icon,article:article,text:text,isShow:true}));
        setHandler(()=>beforeClose);
    }

    return [
        modal,
        closeModal,
        showModal
    ];
}

export default useModal;