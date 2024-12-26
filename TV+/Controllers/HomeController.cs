using Application.Services;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace TV_.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _serieService;

        public HomeController(ApplicationContext dbContext)
        {
            _serieService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            var series = await _serieService.GetAllViewModel();
            return View(series);
        }
       
    }
}
