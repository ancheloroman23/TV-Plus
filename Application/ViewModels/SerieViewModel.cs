

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string UrlPortada { get; set; }
        public string UrlVideo { get; set; }
        public string NombreProductora { get; set; }
        public string GeneroPrimario { get; set; }
        public string GeneroSecundario { get; set; }

        public List<ProductoraViewModel> ProductoraOpciones { get; set; }
        public List<GeneroViewModel> GeneroOpciones { get; set; }
    }
}
