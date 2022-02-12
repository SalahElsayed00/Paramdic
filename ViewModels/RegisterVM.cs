using System.ComponentModel.DataAnnotations;

namespace Paramdic.ViewModels
{
    public class RegisterVM
    {

        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "The Password is not Matched")]
        public string ConfairmPassword { get; set; }
    }
}
