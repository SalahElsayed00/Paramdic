using Paramdic.Models;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="Frist Name")]
        public string FristName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Name { get; set; }

        public Gender gender { get; set; }

        public SocialStatus socialStatus { get; set; }

        public City city { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "The Password is not Matched")]
        public string ConfairmPassword { get; set; }
    }
}
