
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterComm.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
