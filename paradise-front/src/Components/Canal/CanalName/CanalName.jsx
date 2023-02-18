import React from 'react';
import styles from './canalName.module.css'

const CanalName = ({name}) => {
    return (
        <>
            <h2 className={styles.name}>
                {name}
            </h2>
        </>
    );
}

export default CanalName;
