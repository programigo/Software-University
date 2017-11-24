﻿using System.Collections.Generic;

namespace CameraBazaar.Web.Models.Identity
{
    public class UserWithRolesViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
