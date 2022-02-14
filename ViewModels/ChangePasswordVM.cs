using System.ComponentModel.DataAnnotations;

namespace Paramdic.ViewModels
{
    public class ChangePasswordVM
    {
        [Required, Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Compare("NewPassword", ErrorMessage = "Password is not Matched")]
        public string ConfairmPassword { get; set; }
    }
}
