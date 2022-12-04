using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Art_Gallery.Models;

namespace Art_Gallery.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Art_Gallery.Models.art> art { get; set; }
        public DbSet<Art_Gallery.Models.art> Artist { get; set; }

    }
}
