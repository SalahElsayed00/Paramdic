using System;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class Aidrequested
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "National Number")]
        public string NationalId { get; set; }

        [Required, Display(Name = "Birth Date")]
        public DateTime DateOfBirth { get; set; }

        public string Feedback { get; set; }

        [Required, Display(Name = "Date Requested")]
        public DateTime Daterequested { get; set; }

        [Required, Display(Name = "National Image")]
        public byte[] NationalImagePath { get; set; }

        [Required, Display(Name = "Personal Image")]
        public byte[] PersonalImage { get; set; }

        public int SocialStatusId { get; set; }
        [Required, Display(Name = "Social Status")]
        public SocialStatus SocialStatus { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public Category category { get; set; }

        public int StatusID { get; set; }
        [Required]
        public City status { get; set; }



    }
}
