import { useState } from 'react'

const useModal = () => {
    const [modal, setModal] = useState({
        icon:'',
        article:'',
        text:'',
        isShow:false
    });

    function closeModal() {
        setModal(modal =>({...modal, isShow:false}));
    }

    function showModal(icon,article,text){
        setModal(modal =>({...modal, icon:icon,article:article,text:text,isShow:true}));
    }

    return [
        modal,
        closeModal,
        showModal
    ];
}

export default useModal;