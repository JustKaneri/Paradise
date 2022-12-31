using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface ICommentRepository
    {
        public Task<RequestResult<ICollection<Comment>>> GetComments(int idVideo);

        public Task<RequestResult<Comment>> CreateComment(Comment comment);
    }
}
