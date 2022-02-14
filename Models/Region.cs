using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class Region
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<City> cities { get; set; }
    }
}
