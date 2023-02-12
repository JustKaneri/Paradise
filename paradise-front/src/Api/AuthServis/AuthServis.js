import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class AuthServis{
    
    static async login(user){
        const responce = await axios.post(ApiConfig.mainPath+"/api/v1/authentication/login",user);

        return responce;
    }
}