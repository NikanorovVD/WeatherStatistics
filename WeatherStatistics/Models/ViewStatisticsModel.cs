using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WeatherStatistics.Data;

namespace WeatherStatistics.Models
{
    public class ViewStatisticsModel
    {
        [Required]
        [Display(Name = "Year")]
        [Range(1147, 2024)]
        public uint Year { get; set; }
        public Months? Month { get; set; }
        public IEnumerable<WeatherRecord> WeatherRecords { get; set; }
        public ViewStatisticsModel()
        {
            WeatherRecords = new List<WeatherRecord>();
        }
    }

    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
