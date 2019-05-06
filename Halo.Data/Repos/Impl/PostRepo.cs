using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Halo.Domain;
using System.Text;


namespace Halo.Data.Repos.Impl
{
    public class PostRepo: IPostRepo
    {
        private HaloContext _context;

        public PostRepo(HaloContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            IEnumerable<Post> postsToReturn = await _context.Posts.ToListAsync();
            return postsToReturn;
        }

        public async Task<Post> GetPost(Guid id)
        {
            Post postToReturn = await _context.Posts.FirstOrDefaultAsync(po => po.Id == id);
            return postToReturn;
        }

        public async Task<IEnumerable<Post>> CreatePost(Post createdPost)
        {
            await _context.Posts.AddAsync(createdPost);
            await _context.SaveChangesAsync();
            IEnumerable<Post> postsToReturn = await _context.Posts.ToListAsync();
            return postsToReturn;
        }

        public async Task<IEnumerable<Post>> UpdatePost(Guid id, Post updatedPost)
        {
            updatedPost.Id = id;
            _context.Posts.Update(updatedPost);
            await _context.SaveChangesAsync();
            IEnumerable<Post> postsToReturn = await _context.Posts.ToListAsync();
            return postsToReturn;
        }

        public async Task DeletePost(Guid id)
        {
            Post postToDelete = await _context.Posts.FirstOrDefaultAsync(po => po.Id == id);
            _context.Posts.Remove(postToDelete);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
