using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Halo.Domain;
using Halo.Data.Repos;
using Halo.Services.ViewModels;
using Halo.Services.Factory;
using System.Text;
using System.Linq;

namespace Halo.Services.Services.Impl
{
    public class PostService: IPostService
    {
        private IPostRepo _repo;

        public PostService(IPostRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<PostViewModel>> GetPosts()
        {
            IEnumerable<Post> postsToConvert = await _repo.GetPosts();
            IEnumerable<PostViewModel> postsToReturn = postsToConvert.Select(po => ModelFactory.CreateViewModel(po));
            return postsToReturn;
        }

        public async Task<PostViewModel> GetPost(Guid postId)
        {
            Post postToConvert = await _repo.GetPost(postId);
            PostViewModel postToReturn = ModelFactory.CreateViewModel(postToConvert);
            return postToReturn;
        }

        public async Task<IEnumerable<PostViewModel>> CreatePost(UserViewModel user, Guid userId,
                                                                  PostViewModel newPost)
        {
            Post postToCreate = ModelFactory.CreateDomainModel(userId, user, newPost);
            IEnumerable<Post> postsToConvert = await _repo.CreatePost(postToCreate);
            IEnumerable<PostViewModel> postsToReturn = postsToConvert.Select(p => ModelFactory.CreateViewModel(p));
            return postsToReturn;
        }
        public async Task<IEnumerable<PostViewModel>> UpdatePost(UserViewModel user, Guid userId,
                                                                Guid id, PostViewModel updatedPost)
        {
            Post postToUpdate = ModelFactory.CreateDomainModel(userId, user, updatedPost);
            IEnumerable<Post> postsToConvert = await _repo.UpdatePost(id, postToUpdate);
            IEnumerable<PostViewModel> postsToReturn = postsToConvert.Select(p => ModelFactory.CreateViewModel(p));
            return postsToReturn;
        }

        public async Task DeletePost(Guid id)
        {
            await _repo.DeletePost(id);
            return;
        }

    }
}
