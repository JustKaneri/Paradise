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
        public async Task<RequestResult<Comment>> CreateComment(Comment comment)
        {
            RequestResult<Comment> requestResult = new RequestResult<Comment>();

            if (ExistenceModel.User(comment.UserId, _context) == null)
            {
                requestResult.Error = "User not existence";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            if (ExistenceModel.Video(comment.VideoId, _context) == null)
            {
                requestResult.Error = "Video not existence";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            try
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                requestResult.Result = comment;
            }
            catch 
            {
                requestResult.Error = "Failed save comment";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            return requestResult;
        }

        public async Task<RequestResult<ICollection<Comment>>> GetComments(int idVideo)
        {
            RequestResult<ICollection<Comment>> requestResult = new RequestResult<ICollection<Comment>>();

            if (ExistenceModel.Video(idVideo, _context) == null)
            {
                requestResult.Error = "Video not existence";
                requestResult.Status = StatusRequest.Error;
                return requestResult;
            }

            List<Comment> comments = await _context.Comments
                                             .Include(ic => ic.User)
                                             .Include(ic => ic.User.Profile)
                                             .Where(cm => cm.VideoId == idVideo).ToListAsync();

            requestResult.Result = comments;

            return requestResult;
        }
    }
}
 