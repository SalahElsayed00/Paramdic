using System;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class Cases
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string NationalId { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public string Feedback { get; set; }

        public DateTime Daterequested { get; set; }

        public byte[] NationalImagePath { get; set; }

        public byte[] PersonalImage { get; set; }

        [Display(Name ="Social Status")]
        public int SocialStatusId { get; set; }
        public SocialStatus SocialStatus { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        [Display(Name = "Status")]
        public int StatusID { get; set; }
        public Status status { get; set; }



    }
}
