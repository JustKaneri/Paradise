import React,{useState,useEffect} from 'react';
import styles from './alertManage.module.css';
import AlertItem from './AlerItem/AlertItem';

const AlertManager = ({value}) => {

    const [list,setList] = useState([ ])

    useEffect(() => {
        if(value.content == "" || value.type == ""){
            return;
        }

        setList([...list,list.push(value)]);

        setTimeout(()=>{
            setList(...list,list.shift());
        },5000);

    }, [value]);

    return (
        <div className={styles.box}>
            {list.length > 0 && list.map((value)=>
                <AlertItem
                    content={value.content}
                    type = {value.type}
                />
            )}
        </div>
    );
}

export default AlertManager;
