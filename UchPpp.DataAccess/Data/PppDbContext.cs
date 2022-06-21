using Microsoft.EntityFrameworkCore;
using UchPpp.Models;

namespace UchPpp.DataAccess
{
    public class PppDbContext :DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PppDbContext(DbContextOptions<PppDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public DbSet<Project> Projects { get; set; }
    }
}
