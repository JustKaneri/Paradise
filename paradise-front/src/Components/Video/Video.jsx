import React from 'react';
import Player from 'react-custom-player';
import DiscriptVideo from '../DiscriptVideo/DiscriptVideo';
import styles from './video.module.css';

const Video = ({video}) => {

    const content = "Eam id posse dictas voluptua, veniam laoreet oportere no mea, quis regione suscipiantur mea an. Sale liber et vel. Solum vituperata definitiones te vis, vis alia falli doming ea. Tation delenit percipitur at vix. Mandamus abhorreant deseruisse mea at, mea elit deserunt persequeris at, in putant fuisset honestatis qui. Mandamus abhorreant deseruisse mea at, mea elit deserunt persequeris at, in putant fuisset honestatis qui.";

    return (
        <div className={styles.box}>
            <div className={styles.video}>
                <Player  video={video}/>
            </div>
            <DiscriptVideo
                content = {content}
            />
        </div>
    );
}

export default Video;
