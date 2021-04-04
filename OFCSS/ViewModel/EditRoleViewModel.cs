using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.ViewModel
{
    public class EditRoleViewModel
    {
        
            public EditRoleViewModel()
            {
                Users = new List<string>();
            }
            [Key]
            public string Id { get; set; }

            public string RoleName { get; set; }

            public List<string> Users { get; set; }
        
    }
}
