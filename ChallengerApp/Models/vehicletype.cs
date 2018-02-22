using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengerApp.Models
{
    public class vehicletype
    {
        public int Id { get; set; }

        
        public string Brand { get; set; }

       
        public string Model { get; set; }

        
        public int Year { get; set; }

      
        public decimal Price { get; set; }


        public string UserName { get; set; }



        public bool IsNew { get; set; }
    }
}