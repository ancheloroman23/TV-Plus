using Application.Services;
using Application.ViewModels;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace TV_.Controllers
{
    public class DetalleSerieController : Controller
    {
        private readonly SerieService _serieService;

        public DetalleSerieController(ApplicationContext dbContext)
        {
            _serieService = new(dbContext);
        }

        
        public async Task<IActionResult> Index()
        {
            var series = await _serieService.GetAllViewModel();
            return View(series);
        }

        public async Task<IActionResult> VerSerie(int id)
        {
            var serie = await _serieService.GetByIdViewModel(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }
    }

}
