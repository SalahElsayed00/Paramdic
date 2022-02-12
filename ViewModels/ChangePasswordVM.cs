using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paramdic.ViewModels
{
    public class ChangePasswordVM
    {
        [Required,Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }

        [Required,DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password),Compare("NewPassword",ErrorMessage ="Password is not Matched")]
        public string ConfairmPassword { get; set; }
    }
}
