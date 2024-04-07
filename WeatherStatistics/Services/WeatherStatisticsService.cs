using Microsoft.EntityFrameworkCore;
using WeatherStatistics.Data;
using WeatherStatistics.Models;

namespace WeatherStatistics.Services
{
    public class WeatherStatisticsService
    {
        private AppDbContext _dbContext;
        private IStatisticsReader _statisticsReader;

        public WeatherStatisticsService(AppDbContext dbContext, IStatisticsReader statisticsReader)
        {
            _dbContext = dbContext;
            _statisticsReader = statisticsReader;
        }

        public void LoadRecords(Stream stream)
        {
            IEnumerable<WeatherRecord> records = _statisticsReader.ReadStatistics(stream);
            try
            {
                _dbContext.AddRange(records);
                _dbContext.SaveChanges();
            }
            catch
            {
                _dbContext.RemoveRange(records);
                throw new DbUpdateException();
            }
        }

        public IEnumerable<WeatherRecord> GetRecords(uint year, uint? month)
        {
            Func<WeatherRecord, bool> condition = (month == null) ? (r => r.Date.Year == year) : (r => r.Date.Year == year && r.Date.Month == month);
            List<WeatherRecord> records = _dbContext.WeatherRecords.Where(condition).OrderBy(r => r.Date).ThenBy(r => r.Time).ToList();
            return records;
        } 
    }
}
