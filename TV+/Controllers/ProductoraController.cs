using Application.Services;
using Application.ViewModels;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace TV_.Controllers
{
    public class ProductoraController : Controller
    {
        
        private readonly ProductoraService _productoraService;

        public ProductoraController(ApplicationContext dbContext)
        {
            _productoraService = new(dbContext);
        }


        public async Task<IActionResult> Index()
        {
            var productoras = await _productoraService.GetAllViewModel();
            return View(productoras);
        }

        public IActionResult Create()
        {
            return View("SaveProductora", new ProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoraViewModel viewModel)
        {
            await _productoraService.Add(viewModel);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            var productora = await _productoraService.GetByIdViewModel(id);
            if (productora == null)
            {
                return NotFound();
            }
            return View(productora);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoraViewModel productoraViewModel)
        {
            if (id != productoraViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoraService.Update(productoraViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productoraViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productoraService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
