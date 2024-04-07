namespace WeatherStatistics.Models
{
    public class LoadFileResultModel
    {
        public List<IFormFile> SuccessfullyLoadedFiles { get; set; }
        public List<IFormFile> InvalidFiles { get; set; }
        public bool HaveErrors { get => InvalidFiles.Count > 0; }

        public LoadFileResultModel()
        {
            SuccessfullyLoadedFiles = new();
            InvalidFiles = new();
        }
    }
}
