using System;
using System.Collections.Generic;
using System.Text;

namespace Halo.Domain
{
    public class Comment : Entity 
    {
        private Comment() { }

        public Comment(Post post, Guid postId, User author, Guid userId, string username, string avatar)
        {
            Post = post;

            PostId = postId;

            Author = author;

            UserId = userId;

            Username = username;

            Avatar = avatar;
        }
        
        public Post Post { get; set; }

        public Guid PostId { get; set; }

        public User Author { get; set; }
        
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Avatar { get; set; }
    }
}
