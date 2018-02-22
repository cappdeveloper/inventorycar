using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengerApp.Models
{
    public class MyProfileViewModel
    {
        public UserProfileViewModel UserProfileModel { get; set; }
        public LocalPasswordModel LocalPasswordModel { get; set; }
    }
}