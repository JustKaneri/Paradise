import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class AuthServis{
    
    static async login(user){
        const responce = await axios.post(ApiConfig.mainPath+"/api/v1/authentication/login",user);

        return responce;
    }

    static async regestry(user){
        const responce = await axios.post(ApiConfig.mainPath+"/api/v1/authentication/regestry", user);

        return responce;
    }

    static async updateTokens(tokens){
        const responce = await axios.post(ApiConfig.mainPath+"/api/v1/authentication/refresh-token", tokens);

        return responce;
    }
}