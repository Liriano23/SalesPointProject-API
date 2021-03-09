using Microsoft.EntityFrameworkCore;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace backend.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Employers> Employers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Sales> Sales { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
