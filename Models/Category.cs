﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paramdic.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<Aidrequested> aidrequesteds { get; set; }
    }
}
