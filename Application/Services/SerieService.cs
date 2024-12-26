using Application.Repositories;
using Application.ViewModels;
using DataBase;
using DataBase.Models;

namespace Application.Services
{
    public class SerieService
    {
        private readonly SerieRepository _serieRepository;
        private readonly GeneroRepository _generoRepository;
        private readonly ProductoraRepository _productoraRepository;

        public SerieService(ApplicationContext context)
        {
            _serieRepository = new(context);
            _generoRepository = new(context);
            _productoraRepository = new(context);
        }

        public async Task Add(SaveSerieViewModel viewModel)
        {
            var serie = await MapSaveSerieViewModelToSerie(viewModel);
            await _serieRepository.AddAsync(serie);
        }

        public async Task Update(SaveSerieViewModel viewModel)
        {
            var serie = await _serieRepository.GetByIdAsync(viewModel.Id);
            if (serie != null) 
            {
                serie.Id = viewModel.Id;
                serie.Nombre = viewModel.Nombre;
                serie.Descripcion = viewModel.Descripcion;
                serie.UrlPortada = viewModel.UrlPortada;
                serie.UrlVideo = viewModel.UrlVideo;
                serie.Productora = await _productoraRepository.GetByNameAsync(viewModel.NombreProductora);
                serie.Genero = await _generoRepository.GetByNameAsync(viewModel.GeneroPrimario);
                if (!string.IsNullOrEmpty(viewModel.GeneroSecundario))
                {
                    serie.GeneroSecundario = await _generoRepository.GetByNameAsync(viewModel.GeneroSecundario);
                }

                await _serieRepository.UpdateAsync(serie, viewModel.Id);
            }                    
        }

        public async Task<SerieViewModel> GetByIdViewModel(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "El ID de la serie no fue encontrado.");
            }

            var serie = await _serieRepository.GetByIdAsync(id);
            if (serie != null)
            {
                return MapSerieToSerieViewModel(serie);
            }
            return null;
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var series = await _serieRepository.GetAllWithIncludes(new List<string> { "Productora", "Genero" });
            return series.Select(MapSerieToSerieViewModel).ToList();
        }

        public async Task Delete(int id)
        {
            await _serieRepository.DeleteAsync(id);
        }

       


        private async Task<Serie> MapSaveSerieViewModelToSerie(SaveSerieViewModel viewModel)
        {
            return new Serie
            {
                Id = viewModel.Id,
                Nombre = viewModel.Nombre,
                Descripcion = viewModel.Descripcion,
                UrlPortada = viewModel.UrlPortada,
                UrlVideo = viewModel.UrlVideo,
                IdProductora = int.Parse(viewModel.NombreProductora),
                IdGeneroPrimario = int.Parse(viewModel.GeneroPrimario),
                IdGeneroSecundario = string.IsNullOrEmpty(viewModel.GeneroSecundario) ? null : (int?)int.Parse(viewModel.GeneroSecundario)
            };
        }

        private SerieViewModel MapSerieToSerieViewModel(Serie serie)
        {
            return new SerieViewModel
            {
                Id = serie.Id,
                Nombre = serie.Nombre,
                Descripcion = serie.Descripcion,
                UrlPortada = serie.UrlPortada,
                UrlVideo = serie.UrlVideo,
                NombreProductora = serie.Productora != null ? serie.Productora.Nombre : null,
                GeneroPrimario = serie.Genero != null ? serie.Genero.Nombre : null,
                GeneroSecundario = serie.GeneroSecundario != null ? serie.GeneroSecundario.Nombre : null
            };
        }


        public async Task<List<GeneroViewModel>> GetAllGeneros()
        {
            var generos = await _generoRepository.GetAllAsync(); 
            return generos.Select(genero => new GeneroViewModel
            {
                Id = genero.Id,
                Nombre = genero.Nombre
            }).ToList();
        }

        public async Task<List<ProductoraViewModel>> GetAllProductoras()
        {
            var productoras = await _productoraRepository.GetAllAsync(); 
            return productoras.Select(productoras => new ProductoraViewModel
            {
                Id = productoras.Id,
                Nombre = productoras.Nombre
            }).ToList();
        }

    }
}