import React from 'react';
import { getShortDate } from '../../../Other/dateFormater';
import styles from './videoInfo.module.css';

const VideoInfo = ({info}) => {

    const countWathc = () => {
        let countWatch = info.countWatch;

        if(countWatch > 999999){
            countWatch  = countWatch /1000000 + ' млн.';
            return countWatch;
        }

        if(countWatch > 999){
            countWatch = countWatch/1000 + ' тыс.';
            return countWatch
        }
            
        return countWatch;
    }

    return (
        <>
        <span className={styles.info}>
            Опубликовано {getShortDate(info.dateCreate)}
            &emsp;
            Просмотров: {countWathc()}
        </span>   
        </>
    );
}

export default VideoInfo;
