using System;
using System.Collections.Generic;
using System.Text;

namespace Halo.Services.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Avatar { get; set; }
    }
}
