using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengerApp.Models
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        [Required]
        [Display(Name="Role")]
        public string RoleName { get; set; }
    }
}