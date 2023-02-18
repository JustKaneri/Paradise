import React from 'react';
import ButtonSubscrib from '../../ButtonSubscrib/ButtonSubscrib';
import CanalAvatar from '../ProfileAvatar/CanalAvatar';
import CanalFon from '../ProfileFon/CanalFon';
import ProfileInfo from '../ProfileInfo/ProfileInfo';
import styles from './profileCanal.module.css'
import getSrcUser from '../../../UserHook/useSrcUser';
import CanalName from '../CanalName/CanalName';

const ProfileCanal = ({user}) => {
    return (
        <div className={styles.box}>
            <div className={styles.profile}>
                <CanalFon
                    src={getSrcUser.Fon(user)}
                />
                <CanalAvatar
                    src={getSrcUser.Avatar(user)}
                />
                <CanalName
                    name={user.name}
                />
                <ProfileInfo
                    id = {user.id}
                />
            </div>
            <ButtonSubscrib
                id={user.id}
            />
        </div>
    );
}

export default ProfileCanal;
