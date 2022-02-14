using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class SocialStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Aidrequested> aidrequested { get; set; }
        public IEnumerable<ApplicationUser> User { get; set; }
    }
}
