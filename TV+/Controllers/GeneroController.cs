using Application.Services;
using Application.ViewModels;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace TV_.Controllers
{
    public class GeneroController : Controller
    {
        private readonly GeneroService _generoService;

        public GeneroController(ApplicationContext dbContext)
        {
            _generoService = new(dbContext);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _generoService.GetAllViewModel());
        }


        public IActionResult Create()
        {
            return View("SaveGenero", new GeneroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneroViewModel viewModel)
        {
            await _generoService.Add(viewModel);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genero = await _generoService.GetByIdViewModel(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GeneroViewModel generoViewModel)
        {
            if (id != generoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _generoService.Update(generoViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(generoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _generoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
