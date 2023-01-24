﻿using Microsoft.AspNetCore.Identity;

namespace serverapp.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Introduction { get; set; }
        public string? Hobbies { get; set; }
    }
}
