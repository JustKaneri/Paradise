import {useContext} from 'react';
import { AuthContext } from '../Context';
import { useNavigate } from 'react-router-dom';
import getId from './useGetId';

const Redirect = (id) =>  {

    const {IsAuth} =  useContext(AuthContext);
    const router = useNavigate();

    const ToMyProfile = () =>{
        if(IsAuth && id == getId()){
            router('/my-profile');
            return true;
        }
    }

    return [ToMyProfile];
}

export default Redirect;