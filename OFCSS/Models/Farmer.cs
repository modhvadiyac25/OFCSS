using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.Models
{
    public class Farmer
    {
        [Key]
        public int f_id { get; set; }

        [Required]
        public string fname { get; set; }

        [Required]
        public string lname { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string distric { get; set; }

        [Required]
        public string taluka { get; set; }

        [Required]
        public string village { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Mobile no must be 10 digits !!")]
        public string mno { get; set; }


        [MinLength(8, ErrorMessage = "Password must be greater then 8 characters !!")]
        [Required, DataType(DataType.Password)]
        public string password { get; set; }

        public ICollection<CropSale> CropSale { get; set; }
    }
}
