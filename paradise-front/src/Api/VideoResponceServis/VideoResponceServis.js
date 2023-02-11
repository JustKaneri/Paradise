import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class VideoResponceServis{
    
    static async getResponceVideo(id){
        const responce = await axios.get(`${ApiConfig.mainPath}/api/v1/responce-video/video/${id}/count-responce`);

        return responce;
    }
}