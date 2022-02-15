using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }

        public string NationalId { get; set; }

        public byte[] NationalImagePath { get; set; }

        public byte[] PersonalImage { get; set; }

        public int GenderId { get; set; }
        public Gender gender { get; set; }

        public int SocialStatusId { get; set; }
        public SocialStatus socialStatus { get; set; }

        public int CityId { get; set; }
        public City city { get; set; }
    }
}
