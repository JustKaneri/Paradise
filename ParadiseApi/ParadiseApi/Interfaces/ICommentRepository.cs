using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface ICommentRepository
    {
        public ICollection<Comment> GetComments(int idVideo, ref string error);

        public Comment CreateComment(Comment comment, ref string error);
    }
}
