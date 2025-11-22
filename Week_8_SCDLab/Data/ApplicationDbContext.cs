using Microsoft.EntityFrameworkCore;
using Week_8_SCDLab.Models;

namespace Week_8_SCDLab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
