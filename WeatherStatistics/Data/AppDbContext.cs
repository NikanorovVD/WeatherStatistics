using Microsoft.EntityFrameworkCore;

namespace WeatherStatistics.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<WeatherRecord> WeatherRecords { get; set; }
    }
}
