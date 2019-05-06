using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Halo.Services.Factory;
using Halo.Services.ViewModels;
using Halo.Data.Repos;
using System.Text;
using System.Linq;
using Halo.Domain;

namespace Halo.Services.Services.Impl
{
    public class CommentService: ICommentService
    {
        private ICommentRepo _repo;
        public CommentService(ICommentRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CommentViewModel>> GetComments()
        {
            IEnumerable<Comment> commentsToConvert = await _repo.GetComments();
            IEnumerable<CommentViewModel> commentsToReturn = commentsToConvert.Select(c => ModelFactory.CreateViewModel(c));
            return commentsToReturn;
        }

        public async Task<CommentViewModel> GetComment(Guid id)
        {
            Comment commentToConvert = await _repo.GetComment(id);
            CommentViewModel commentToReturn = ModelFactory.CreateViewModel(commentToConvert);
            return commentToReturn;
        }

        public async Task<IEnumerable<CommentViewModel>> CreateComment( UserViewModel user, Guid userId,
                                                                        PostViewModel post, Guid postId,
                                                                        CommentViewModel newComment)
        {
            Comment commentToAdd = ModelFactory.CreateDomainModel(user, userId, post, postId, newComment);
            IEnumerable<Comment> commentAddedToConvert = await _repo.CreateComment(commentToAdd);
            IEnumerable<CommentViewModel> commentsToReturn = commentAddedToConvert.Select(co => ModelFactory.CreateViewModel(co));
            return commentsToReturn;
        }

        public async Task<IEnumerable<CommentViewModel>> UpdateComment( UserViewModel user, Guid userId,
                                                                        PostViewModel post, Guid postId,
                                                                        CommentViewModel updatedComment, Guid id)
        {
            Comment commentToUpdate = ModelFactory.CreateDomainModel(user, userId, post, postId, updatedComment);
            IEnumerable<Comment> commentUpdatedToConvert = await _repo.UpdateComment(id, commentToUpdate);
            IEnumerable<CommentViewModel> commentsToReturn = commentUpdatedToConvert.Select(co => ModelFactory.CreateViewModel(co));
            return commentsToReturn;
        }

        public async Task DeleteComment(Guid id)
        {
            await _repo.DeleteComment(id);
            return;
        }
    }
}
