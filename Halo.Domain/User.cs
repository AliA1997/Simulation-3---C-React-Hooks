using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Halo.Domain
{
    public class User : IdentityUser
    {
        private User() { }

        public User(string username, string passwordHash, string avatar)
        {
            UserName = username;

            PasswordHash = passwordHash;

            Avatar = avatar;
        }

        public Guid Id { get; set; }

        public override string UserName { get; set; }

        public string Avatar { get; set; }
    }
}
