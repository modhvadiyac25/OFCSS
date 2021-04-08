using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.Models
{
    public class MerchantRequirment
    {
        [Key]
        public int mr_id { get; set; }

        [Required]
        public string mr_name { get; set; }

        [Required]
        public string mr_quantity { get; set; }

        [Required]
        public string mr_price { get; set; }

        [Required]
        public string mr_discription { get; set; }
         
        public int m_id { get; set; }
        public Merchant Merchant { get; set; }
    }
}
