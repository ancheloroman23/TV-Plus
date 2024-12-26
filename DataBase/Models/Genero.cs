
namespace DataBase.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Navigation Property 
        public ICollection<Serie>? Series { get; set; }        


    }
}
