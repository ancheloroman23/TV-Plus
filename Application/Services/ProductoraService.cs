using Application.Repositories;
using Application.ViewModels;
using DataBase;
using DataBase.Models;

namespace Application.Services
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _productoraRepository;
        

        public ProductoraService(ApplicationContext context)
        {            
            _productoraRepository = new(context);
        }

        public async Task Add(ProductoraViewModel productoraViewModel)
        {
            var productora = new Productora
            {
                Nombre = productoraViewModel.Nombre
            };
            await _productoraRepository.AddAsync(productora);
        }

        public async Task Update(ProductoraViewModel productoraViewModel)
        {
            var existingProductora = await _productoraRepository.GetByIdAsync(productoraViewModel.Id);
            if (existingProductora != null)
            {
                existingProductora.Nombre = productoraViewModel.Nombre;
                await _productoraRepository.UpdateAsync(existingProductora, productoraViewModel.Id); 
            }
        }

        public async Task<ProductoraViewModel> GetByIdViewModel(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);
            if (productora != null)
            {
                return new ProductoraViewModel
                {
                    Id = productora.Id,
                    Nombre = productora.Nombre
                };
            }
            return null;
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var productoras = await _productoraRepository.GetAllAsync();
            return productoras.Select(p => new ProductoraViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToList();
        }

        public async Task Delete(int id)
        {
            await _productoraRepository.DeleteAsync(id);
        }
    }
}
