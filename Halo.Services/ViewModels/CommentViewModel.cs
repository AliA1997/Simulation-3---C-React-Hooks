using System;
using System.Collections.Generic;
using System.Text;

namespace Halo.Services.ViewModels
{
    public class CommentViewModel
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Avatar { get; set; }

    }
}
