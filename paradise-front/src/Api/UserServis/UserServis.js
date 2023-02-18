import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class UserServis{

    static async getCurrentUser(idUser){
        const responce = await axios.get(ApiConfig.mainPath + '/api/v1/users/' + idUser);

        return responce;
    }

    static async getAuthUser(token){
        const responce =  axios.get(ApiConfig.mainPath + '/api/v1/users/auth', 
                                            { 
                                                headers: 
                                                    {
                                                        "Authorization" : `Bearer ${token}`
                                                    } 
                                            });

        return responce;
    }

    static async getUserInfo(id){
        const response = axios.get(ApiConfig.mainPath + `/api/v1/user-information/user/${id}/detailed-information`);

        return response;
    }

}