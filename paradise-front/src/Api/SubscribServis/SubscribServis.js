import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class SubscribServis{

    static async getSubscrib(token){
        const responce =  axios.get(ApiConfig.mainPath + '/api/v1/subscription/subscriptions', 
                                    { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

    static async subscribsStatus(idCanal,token){
        const responce =  axios.get(ApiConfig.mainPath + `/api/v1/subscription/user/${idCanal}/subscription/status`,  
                                    { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

    static async subscribs(idCanal,token){
        const responce =  axios.post(ApiConfig.mainPath + `/api/v1/subscription/user/${idCanal}/subscribe`,null, 
                                    { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

    static async unSubscribs(idCanal,token){
        const responce =  axios.delete(ApiConfig.mainPath + `/api/v1/subscription/user/${idCanal}/unsubscribe`,  
                                       { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

}