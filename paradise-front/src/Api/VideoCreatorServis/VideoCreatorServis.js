import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class VideoCreatorServis{

    static async createideo(data,token){

        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/video/video/create`, data,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`
                } 
        });;

        return responce;
    }

    static async uploadPoster(idVideo,data,token){

        var file = new FormData();

        file.append("file", data);

        const responce = await axios.post(`${ApiConfig.mainPath}api/v1/video/video/${idVideo}/upload-poster`, file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Content-Type': 'multipart/form-data'
                } 
        });;

        return responce;
    }

    static async uploadVideo(idVideo,data,token){

        var file = new FormData();

        file.append("file", data);

        const responce = await axios.post(`${ApiConfig.mainPath}api/v1/video/video/${idVideo}/upload-video`, file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Content-Type': 'multipart/form-data'
                } 
        });;

        return responce;
    }
}