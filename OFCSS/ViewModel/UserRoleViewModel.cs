using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.ViewModel
{
    public class UserRoleViewModel
    {
            [Key]
            public string UserId { get; set; }
    
            public string UserName { get; set; }
            public bool isSelected { get; set; }
    }
}
