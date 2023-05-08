import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class ProfileServis{
    
    static async updateAvatar(data,token){

        var file = new FormData();

        file.append("file", data);

        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/user/profile/upload-avatar`,file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Content-Type': 'multipart/form-data'
                } 
        });;

        return responce;
    }

    static async updateFon(data,token){

        var file = new FormData();

        file.append("file", data);

        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/user/profile/upload-fon`,file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Content-Type': 'multipart/form-data'
                } 
        });;

        return responce;
    }
}