using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paramdic.Models
{
    public class Mediator:IdentityUser
    {
        public string Address { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
