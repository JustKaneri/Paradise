import axios from "axios";

export default class VideoResponceServis{
    
    static async getResponceVideo(id){
        const responce = await axios.get(`https://localhost:7077/api/v1/responce-video/video/${id}/count-responce`);

        return responce;
    }
}