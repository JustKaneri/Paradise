import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class VideoResponceServis{
    
    static async getResponceCountVideo(id){
        const responce = await axios.get(`${ApiConfig.mainPath}/api/v1/responce-video/video/${id}/count-responce`);

        return responce;
    }

    static async getResponceVideo(id,token){
        const responce = await axios.get(`${ApiConfig.mainPath}/api/v1/responce-video/video/${id}/info-responce`,
                                        { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

    static async setLikeResponce(id,token){
        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/responce-video/like?idVideo=${id}`,null,
                                        { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

    static async setDisLikeResponce(id,token){
        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/responce-video/dislike?idVideo=${id}`,null,
                                        { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

    static async resetResponce(id,token){
        const responce = await axios.delete(`${ApiConfig.mainPath}/api/v1/responce-video/reset?idVideo=${id}`,
                                        { headers: { "Authorization" : `Bearer ${token}`} });

        return responce;
    }

}