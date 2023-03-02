import React from 'react';
import styles from './pageName.module.css'

const PageName = ({content}) => {
    return (
        <span className={styles.name}>
            {content}
        </span>
    );
}

export default PageName;
