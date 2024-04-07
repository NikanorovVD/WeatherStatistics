using WeatherStatistics.Data;

namespace WeatherStatistics.Services
{
    public interface IStatisticsReader
    {
        public IEnumerable<WeatherRecord> ReadStatistics(Stream stream);
    }
}
