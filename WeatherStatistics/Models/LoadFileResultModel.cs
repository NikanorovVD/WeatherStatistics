namespace WeatherStatistics.Models
{
    public class LoadFileResultModel
    {
        public List<IFormFile> SuccessfullyLoadedFiles { get; set; }
        public List<IFormFile> InvalidFormatFiles { get; set; }
        public List<IFormFile> ConflictingDataFiles { get; set; }
        public bool HaveErrors { get => InvalidFormatFiles.Count > 0 || ConflictingDataFiles.Count > 0; }

        public LoadFileResultModel()
        {
            SuccessfullyLoadedFiles = new();
            InvalidFormatFiles = new();
            ConflictingDataFiles = new();
        }
    }
}
