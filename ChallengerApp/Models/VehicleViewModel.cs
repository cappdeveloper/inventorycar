using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengerApp.Models
{
    public class VehicleViewModel
    {
       public VehicleViewModel()
        {

        }
        public int Id { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name="Year Manufactured")]
        public int Year { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Added by")]
        public string UserName { get; set; }

        [Display(Name = "Is New")]
        public bool IsNew { get; set; }



    }
}