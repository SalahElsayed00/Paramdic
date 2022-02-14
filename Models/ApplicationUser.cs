using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class CustomUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "National Number")]
        public string NationalId { get; set; }

        [Required, Display(Name = "National Image")]
        public byte[] NationalImagePath { get; set; }

        [Required, Display(Name = "Personal Image")]
        public byte[] PersonalImage { get; set; }

        public int GenderId { get; set; }
        public Gender gender { get; set; }

        public int SocialStatusId { get; set; }
        public SocialStatus socialStatus { get; set; }

        public int CityId { get; set; }
        public City city { get; set; }
    }
}
