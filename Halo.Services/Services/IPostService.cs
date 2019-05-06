using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Halo.Services.ViewModels;
using System.Text;

namespace Halo.Services.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetPosts();

        Task<PostViewModel> GetPost(Guid id);

        Task<IEnumerable<PostViewModel>> CreatePost(UserViewModel user, Guid userId, PostViewModel newPost);

        Task<IEnumerable<PostViewModel>> UpdatePost(UserViewModel user, Guid userId,
                                                    Guid id, PostViewModel updatedPost);

        Task DeletePost(Guid id);
    }
}
