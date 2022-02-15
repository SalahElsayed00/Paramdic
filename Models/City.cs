using System.Collections.Generic;

namespace Paramdic.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RegionId { get; set; }
        public Region region { get; set; }

       
    }
}
