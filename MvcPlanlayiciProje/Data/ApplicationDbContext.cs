using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcPlanlayiciProje.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcPlanlayiciProje.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Plan> Plans { get; set; }

    }
}
