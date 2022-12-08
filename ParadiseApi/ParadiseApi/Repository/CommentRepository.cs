using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

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
            if (ExistenceModel.User(comment.UserId, _context) == null)
                return null;

            if (ExistenceModel.Video(comment.VideoId, _context) == null)
                return null;


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
 