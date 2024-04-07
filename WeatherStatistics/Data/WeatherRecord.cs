namespace WeatherStatistics.Data
{
    public class WeatherRecord
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public decimal? Temperature {  get; set; }
        public ushort? RelativeHumidity {  get; set; }
        public decimal? Td {  get; set; }
        public ushort? AtmosphericPressure {  get; set; }
        public string? WindDirection { get; set; }
        public ushort? WindSpeed { get; set; }
        public ushort? CloudCover { get; set; }
        public ushort? H { get; set; }
        public string? VV { get; set; }
        public string? WeatherPhenomena {  get; set; }
    }
}
