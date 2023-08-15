import React,{useState,useEffect} from 'react';
import styles from './alertManage.module.css';
import AlertItem from './AlerItem/AlertItem';

const AlertManager = ({value}) => {

    const [list,setList] = useState([]);

    useEffect(() => {
        if(value.content == "" || value.type == ""){
            return;
        }

        setList([...list,value]);

        let id = value.id;
        setTimeout(function(id){
            setList(list=> list.filter(a=>a.id != id));
        },4500,id);

    }, [value]);

    return (
        <div className={styles.box}>
            {list.length > 0 && list.map((value,index)=>
                <AlertItem
                    id = {value.id}
                    key = {index}
                    content={value.content}
                    type = {value.type}
                    time = {3500}
                />
            )}
        </div>
    );
}

export default AlertManager;
