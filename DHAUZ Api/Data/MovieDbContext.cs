using DHAUZ_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DHAUZ_Api.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MovieVM> property { get; set; }
    }
}
