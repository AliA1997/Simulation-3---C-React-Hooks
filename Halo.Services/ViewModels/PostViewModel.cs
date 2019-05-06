using System;
using System.Collections.Generic;
using System.Text;

namespace Halo.Services.ViewModels
{
    public class PostViewModel
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string PostImage { get; set; }
    }
}
