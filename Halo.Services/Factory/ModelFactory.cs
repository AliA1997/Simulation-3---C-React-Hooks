using System;
using System.Collections.Generic;
using System.Text;
using Halo.Services.ViewModels;
using Halo.Domain;

namespace Halo.Services.Factory
{
    public static class ModelFactory
    {
        public static UserViewModel CreateViewModel(User user)
        {
            return new UserViewModel()
            {
                UserName = user.UserName,
                PasswordHash = "passwordHash",
                Avatar = user.Avatar
            };
        }

        public static CommentViewModel CreateViewModel(Comment newComment)
        {
            return new CommentViewModel()
            {
                UserId = newComment.UserId,
                PostId = newComment.PostId,
                Username = newComment.Username,
                Avatar = newComment.Avatar
            };
        }

        public static PostViewModel CreateViewModel(Post newPost)
        {
            return new PostViewModel()
            {
                UserId = newPost.UserId,
                Title = newPost.Title,
                Body = newPost.Body,
                PostImage = newPost.PostImage
            };
        }

        public static User CreateDomainModel(UserViewModel user)
        {
            return new User(
                    user.UserName,
                    user.PasswordHash,
                    user.Avatar
                );
        }

        public static Post CreateDomainModel( Guid userId, UserViewModel user, PostViewModel post)
        {

            return new Post(
                    userId,
                    CreateDomainModel(user),
                    post.Title,
                    post.Body,
                    post.PostImage
                );

        }

        public static Comment CreateDomainModel(UserViewModel user, Guid userId,
                                                PostViewModel post, Guid postId, 
                                                CommentViewModel newComment)
        {
            return new Comment(
                    CreateDomainModel(userId, user, post),
                    postId,
                    CreateDomainModel(user),
                    userId,
                    newComment.Username,
                    newComment.Avatar
                );
        }
    }
}
