using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext>options) : base(options)
        {
            
        }
        public DbSet<Photo> Kenneth_Cars { get; set; }
    }
}
