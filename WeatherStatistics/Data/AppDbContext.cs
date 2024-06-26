﻿using Microsoft.EntityFrameworkCore;

namespace WeatherStatistics.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherRecord>().HasKey(u => new { u.Date, u.Time });
        }
        public DbSet<WeatherRecord> WeatherRecords { get; set; }
    }
}
