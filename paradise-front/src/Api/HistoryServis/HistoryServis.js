import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class HistoryServis{
    
    static async getHistory(token){
        const responce = await axios.get(`${ApiConfig.mainPath}/api/v1/history`, 
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`
                } 
        });;

        return responce;
    }

    static async createEnityHistory(idVideo,token){
        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/history/create?idVideo=${idVideo}`,null,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`
                } 
        });;

        return responce;
    }
}