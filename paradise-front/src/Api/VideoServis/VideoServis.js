import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class VideoServis{
    static async getAll(){
        const responce = await axios.get(ApiConfig.mainPath + '/api/v1/video/videos');

        return responce;
    }

    static async getCurrentVideo(id){
        const responce = await axios.get(ApiConfig.mainPath + '/api/v1/video/video/' + id);

        return responce;
    }

    static async getVideoSelectUser(idUser){
        const responce = await axios.get(ApiConfig.mainPath + `/api/v1/video/user/${idUser}/video`);

        return responce;
    }
}