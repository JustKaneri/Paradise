import React from 'react';
import { useState } from 'react';
import { useEffect } from 'react';
import UserServis from '../../../Api/UserServis/UserServis';
import { useFetching } from '../../../UserHook/useFeatching';
import styles from './profileInfo.module.css';

const ProfileInfo = ({id}) => {

    const [info,setInfo] = useState({
        "countWatch": 0,
        "countSubscrib": 0
    });

    const [fetch,error] = useFetching(async()=>{
        const responce = await UserServis.getUserInfo(id);

        setInfo({...responce.data});
    });

    useEffect(()=>{
        fetch();
    },[]);

    const getCount = (num) => {
        let count= num;

        if(count > 999999){
            count  = count /1000000 + ' млн.';
            return count;
        }

        if(count > 999){
            count = count/1000 + ' тыс.';
            return count;
        }
            
        return count;
    }

    return (
        <div className={styles.block}>
            <span className={styles.info}>
                Подписчиков: {getCount(info.countSubscrib)}
            </span>
            <span className={styles.info}>
                Просмотров: {getCount(info.countWatch)}
            </span>
        </div>
    );
}

export default ProfileInfo;
