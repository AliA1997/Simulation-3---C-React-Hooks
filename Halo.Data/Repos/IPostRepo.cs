using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Halo.Domain;

namespace Halo.Data.Repos
{
    public interface IPostRepo
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(Guid id);

        Task<IEnumerable<Post>> CreatePost(Post newPost);

        Task<IEnumerable<Post>> UpdatePost(Guid id, Post updatedPost);

        Task DeletePost(Guid id);
    }
}
