import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class VideoCreatorServis{

    static async createVideo(data,files,token){

        var file = new FormData();

        const json = JSON.stringify(data);

        file.append('videoInfo',json)
        file.append("files", files.video);
        if(files.poster)
            file.append("files", files.poster);

        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/creator-video/video/create`, file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Accept': 'application/json',
                    'Content-Type': 'multipart/form-data'
                },
                onUploadProgress: function(progressEvent) {
                     console.log(parseInt(Math.round(( progressEvent.loaded / progressEvent.total) * 100)));
                }.bind(this)
                
        });;

        return responce;
    }

    static async uploadPoster(idVideo,data,token){

        var file = new FormData();

        file.append("file", data);

        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/video/video/${idVideo}/upload-poster`, file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Content-Type': 'multipart/form-data'
                } 
        });

        return responce;
    }

    static async uploadVideo(idVideo,data,token){

        var file = new FormData();
        file.append("file", data);

        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/video/video/${idVideo}/upload-video`, file,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`,
                    'Content-Type': 'multipart/form-data'
                } 
        });

        return responce;
    }
}