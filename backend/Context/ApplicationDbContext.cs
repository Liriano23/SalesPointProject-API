using Microsoft.EntityFrameworkCore;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Users> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
