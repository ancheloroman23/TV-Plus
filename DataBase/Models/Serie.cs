
namespace DataBase.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string UrlPortada { get; set; }
        public string UrlVideo { get; set; }        
        public int IdProductora { get; set; }
        public int IdGeneroPrimario { get; set; }
        public int? IdGeneroSecundario { get; set; }

        //Navigation Property 
        public Genero? Genero { get; set; }
        public Genero? GeneroSecundario { get; set; }
        public Productora? Productora { get; set; }

    }
}
