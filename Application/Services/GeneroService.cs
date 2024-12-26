using Application.Repositories;
using Application.ViewModels;
using DataBase.Models;
using DataBase;

namespace Application.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository _generoRepository;


        public GeneroService(ApplicationContext context)
        {
            _generoRepository = new(context);
        }

        public async Task Add(GeneroViewModel generoViewModel)
        {
            var genero = new Genero
            {
                Nombre = generoViewModel.Nombre
            };
            await _generoRepository.AddAsync(genero);
        }

        public async Task Update(GeneroViewModel generoViewModel)
        {
            var existingGenero = await _generoRepository.GetByIdAsync(generoViewModel.Id);
            if (existingGenero != null)
            {
                existingGenero.Nombre = generoViewModel.Nombre;
                await _generoRepository.UpdateAsync(existingGenero, generoViewModel.Id);
            }
        }

        public async Task<GeneroViewModel> GetByIdViewModel(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            if (genero != null)
            {
                return new GeneroViewModel
                {
                    Id = genero.Id,
                    Nombre = genero.Nombre
                };
            }
            return null;
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generos = await _generoRepository.GetAllAsync();
            return generos.Select(p => new GeneroViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToList();
        }

        public async Task Delete(int id)
        {
            await _generoRepository.DeleteAsync(id);
        }
    }
}
