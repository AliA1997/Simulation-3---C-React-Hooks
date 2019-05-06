using System;

namespace Halo.Domain
{
    public class Post: Entity
    {
        private Post() { }

        public Post(Guid userId, User author, string title, string body, string postImage)
        {
            UserId = userId;

            Author = author;

            Title = title;

            Body = body;

            PostImage = postImage;
        }

        public Guid UserId { get; set; }

        public User Author { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string PostImage { get; set; }

    }
}
