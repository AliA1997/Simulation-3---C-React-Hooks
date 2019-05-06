using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Halo.Domain;

namespace Halo.Data.Repos
{
    public interface ICommentRepo
    {

        Task<IEnumerable<Comment>> GetComments();

        Task<Comment> GetComment(Guid commentId);

        Task<IEnumerable<Comment>> CreateComment(Comment newComment);

        Task<IEnumerable<Comment>> UpdateComment(Guid id, Comment updatedComment);

        Task DeleteComment(Guid id);
    }
}
