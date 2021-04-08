using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.ViewModel
{
    public class CreateCropSaleViewModel
    {
        [Key]
        public int c_id { get; set; }

        [Required]
        public string cname { get; set; }

        [Required]
        public string cquantity { get; set; }

        [Required]
        public string cprice { get; set; }

        [Required]
        public string cdiscription { get; set; }
    }
}
