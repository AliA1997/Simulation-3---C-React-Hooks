using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Halo.Services.ViewModels;

namespace Halo.Services.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetComments();

        Task<CommentViewModel> GetComment(Guid id);

        Task<IEnumerable<CommentViewModel>> CreateComment(  UserViewModel user, Guid userId,
                                                            PostViewModel post, Guid postId,
                                                            CommentViewModel newComment);

        Task<IEnumerable<CommentViewModel>> UpdateComment(  UserViewModel user, Guid userId,
                                                            PostViewModel post, Guid postId,
                                                            CommentViewModel updatedComment, Guid id);

        Task DeleteComment(Guid id);
    }
}
