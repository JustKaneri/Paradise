using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface ICommentRepository
    {
        public ICollection<Comment> GetComments(int idVideo);

        public Comment CreateComment(Comment comment);
    }
}
