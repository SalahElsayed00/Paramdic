using Paramdic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paramdic.ViewModels
{
    public class AidrequestedVM
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Feedback { get; set; }
        public DateTime Daterequested { get; set; }
        public byte[] NationalImagePath { get; set; }
        public byte[] PersonalImage { get; set; }
        [Display(Name = "Social Status")]
        public int SocialStatusId { get; set; }
        public IEnumerable<SocialStatus> SocialStatus{ get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Category { get; set; }
        [Display(Name = "Status")]
        public int StatusID { get; set; }
        public IEnumerable<Status> status { get; set; }
    }
}
