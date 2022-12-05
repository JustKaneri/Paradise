using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }
        public Comment CreateComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            catch 
            {
                return null;
            }

            return comment;
        }

        public ICollection<Comment> GetComments(int idVideo)
        {
            List<Comment> comments = _context.Comments
                                             .Include(ic => ic.User)
                                             .Include(ic => ic.User.Profile)
                                             .Where(cm => cm.VideoId == idVideo).ToList();

            return comments;
        }
    }
}
