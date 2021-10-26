using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPlanlayiciProje.Data.Entities
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<Plan> Plans { get; set; }
    }
}
