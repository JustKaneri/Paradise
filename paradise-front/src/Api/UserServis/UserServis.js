import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class UserServis{

    static async getCurrentUser(idUser){
        const responce = await axios.get(ApiConfig.mainPath + '/api/v1/users/' + idUser);

        return responce;
    }

}