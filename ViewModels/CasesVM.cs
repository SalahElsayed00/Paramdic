using Paramdic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paramdic.ViewModels
{
    public class CasesVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required ,DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required,MaxLength(14,ErrorMessage ="sorry thw National number s not valid. the National number contain 14 number"),MinLength(14,ErrorMessage = "the National number contain 14 number")]
        public string NationalId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Feedback { get; set; }
        [Required]
        public DateTime Daterequested { get; set; }
        [Display(Name = "Choose Your National Image")]
        public byte[] NationalImagePath { get; set; }
        [Display(Name = "Choose Your Personal Image")]
        public byte[] PersonalImage { get; set; }
        [Display(Name = "Social Status"),Required]
        public int SocialStatusId { get; set; }
        public IEnumerable<SocialStatus> SocialStatus{ get; set; }
        [Display(Name = "Category"), Required]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Category { get; set; }
        [Display(Name = "Status"), Required]
        public int StatusID { get; set; }
        public IEnumerable<Status> status { get; set; }
    }
}
