import axios from "axios";

export default class CommentServis{
    
    static async getComments(id){
        const responce = await axios.get(`https://localhost:7077/api/v1/comment/comments?idVideo=${id}`);

        return responce;
    }
}