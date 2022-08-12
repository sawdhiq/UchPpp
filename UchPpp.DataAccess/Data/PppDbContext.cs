using Microsoft.EntityFrameworkCore;
using UchPpp.Models;

namespace UchPpp.DataAccess
{
    public class PppDbContext :DbContext
    {

        public PppDbContext(DbContextOptions<PppDbContext> options) : base(options)

        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
