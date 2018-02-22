using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengerApp.Models
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            Roles = new List<string>();
        }
        
        public int UserId { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name="Email")]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Active")]
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [Display(Name="Roles")]
        public string RoleName { get; set; }

        public List<string> Roles { get; set; }

        public string[] SystemRoles { get; set; }
    }
}