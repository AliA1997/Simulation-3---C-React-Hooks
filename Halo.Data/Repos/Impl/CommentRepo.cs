using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Halo.Domain;
using Halo.Data.Repos;
using System.Text;

namespace Halo.Data.Repos.Impl
{
    public class CommentRepo : ICommentRepo
    {
        private HaloContext _context;

        public CommentRepo(HaloContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            IEnumerable<Comment> commentsToReturn = await _context.Comments.ToListAsync();
            return commentsToReturn;
        }

        public async Task<Comment> GetComment(Guid id)
        {
            Comment commentToReturn = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            return commentToReturn;
        }

        public async Task<IEnumerable<Comment>> CreateComment(Comment createdComment)
        {
            await _context.Comments.AddAsync(createdComment);
            await _context.SaveChangesAsync();
            IEnumerable<Comment> commentsToReturn = await _context.Comments.ToListAsync();
            return commentsToReturn;
        }

        public async Task<IEnumerable<Comment>> UpdateComment(Guid id, Comment updatedComment)
        {
            updatedComment.Id = id;
            _context.Comments.Update(updatedComment);
            await _context.SaveChangesAsync();
            IEnumerable<Comment> commentsToReturn = await _context.Comments.ToListAsync();
            return commentsToReturn;
        }

        public async Task DeleteComment(Guid id)
        {
            Comment commentToRemove = await _context.Comments.FirstOrDefaultAsync(co => co.Id == id);
            _context.Remove(commentToRemove);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
