using Application.Services;
using Application.ViewModels;
using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace TV_.Controllers
{
    public class SerieController : Controller
    {
        private readonly SerieService _serieService;        

        public SerieController(ApplicationContext dbContext)
        {
            _serieService = new(dbContext);            
        }
              
        public async Task<IActionResult> Index()
        {
            var series = await _serieService.GetAllViewModel();
            return View(series);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new SaveSerieViewModel();
            viewModel.GeneroOpciones = await _serieService.GetAllGeneros();
            viewModel.ProductoraOpciones = await _serieService.GetAllProductoras();
            return View("SaveSerie", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel viewModel)
        {
            await _serieService.Add(viewModel);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        
        public async Task<IActionResult> Edit()
        {
            var serie = new SaveSerieViewModel();
            serie.GeneroOpciones = await _serieService.GetAllGeneros();
            serie.ProductoraOpciones = await _serieService.GetAllProductoras();
            return View("Edit", serie);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel saveSerieViewModel)
        {            

            
                await _serieService.Update(saveSerieViewModel);
                saveSerieViewModel.GeneroOpciones = await _serieService.GetAllGeneros();
                saveSerieViewModel.ProductoraOpciones = await _serieService.GetAllProductoras();


            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _serieService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
