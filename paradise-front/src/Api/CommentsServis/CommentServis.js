import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class CommentServis{
    
    static async getComments(id){
        const responce = await axios.get(`${ApiConfig.mainPath}/api/v1/comment/comments?idVideo=${id}`);

        return responce;
    }
}