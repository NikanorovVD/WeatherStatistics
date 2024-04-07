using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using WeatherStatistics.Models;
using WeatherStatistics.Services;

namespace WeatherStatistics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private WeatherStatisticsService _weatherStatisticsService;

        public HomeController(ILogger<HomeController> logger, WeatherStatisticsService weatherStatisticsService)
        {
            _logger = logger;
            _weatherStatisticsService = weatherStatisticsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadFile()
        {
            return View();
        }

        public IActionResult ViewStatistics()
        {
            return View(new ViewStatisticsModel() { Year = 2010 });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ViewStatistics(ViewStatisticsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            model.WeatherRecords = _weatherStatisticsService.GetRecords(model.Year, (uint?)model.Month);
            return View(model);
        }

        [HttpPost]
        public IActionResult LoadFile(LoadFileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            LoadFileResultModel resultModel = new();
            foreach (IFormFile file in model.Files)
            {
                try
                {
                    _weatherStatisticsService.LoadRecords(file.OpenReadStream());
                    resultModel.SuccessfullyLoadedFiles.Add(file);
                }
                catch 
                {
                    resultModel.InvalidFiles.Add(file);
                }
            }
            return View("LoadFileResult", resultModel);
        }
    }
}
