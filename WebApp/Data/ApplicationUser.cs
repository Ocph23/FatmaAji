﻿using Microsoft.AspNetCore.Identity;

namespace WebApp.Data
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }

    }
}
