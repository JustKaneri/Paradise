import React from 'react';
import styles from './canalEdit.module.css'
import CanalUpdateAva from './CanalUpdateAva/CanalUpdateAva';
import CanalUpdateFon from './CanalUpdateFon/CanalUpdateFon';

const CanalEdit = () => {
    return (
        <div>
            <CanalUpdateAva
                styles = {styles.btn}
            />
            <CanalUpdateFon
                styles = {styles.btn}
            />
        </div>
    );
}

export default CanalEdit;
