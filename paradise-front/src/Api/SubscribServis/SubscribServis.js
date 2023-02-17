import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class SubscribServis{

    static async getSubscrib(token){
        const responce =  axios.get(ApiConfig.mainPath + '/api/v1/subscription/subscriptions', 
                                            { 
                                                headers: 
                                                    {
                                                        "Authorization" : `Bearer ${token}`
                                                    } 
                                            });

        return responce;
    }

}