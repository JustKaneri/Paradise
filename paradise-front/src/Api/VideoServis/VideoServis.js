import axios from "axios";

export default class VideoServis{
    static async getAll(){
        const responce = await axios.get('https://localhost:7077/api/v1/video/videos');

        return responce;
    }

    static async getCurrentVideo(id){
        const responce = await axios.get('https://localhost:7077/api/v1/video/video/' + id);

        return responce;
    }
}