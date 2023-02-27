import axios from "axios";
import ApiConfig from "../ApiConfig";

export default class CommentServis{
    
    static async getComments(id){
        const responce = await axios.get(`${ApiConfig.mainPath}/api/v1/comment/comments?idVideo=${id}`);

        return responce;
    }

    static async createComment(data,token){
        const responce = await axios.post(`${ApiConfig.mainPath}/api/v1/comment/new-comment`,data,
        { 
            headers: 
                {
                    "Authorization" : `Bearer ${token}`
                } 
        });;

        return responce;
    }
}