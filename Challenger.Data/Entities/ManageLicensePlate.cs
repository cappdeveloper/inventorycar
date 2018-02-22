using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Data.Entities
{
    class ManageLicensePlate
    {
        [Table("LicensePlate")]
        public class Vehicle
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string PlateNumber { get; set; }
            public int status { get; set; }
            public string PlateType { get; set; }
          
            public string Supplier { get; set; }

            public string Customer { get; set; }

            public DateTime ExpiryDate { get; set; }
            public DateTime DateRecieved { get; set; }

         
        }
    }
}
