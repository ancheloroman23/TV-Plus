

namespace DataBase.Models
{
    public class Productora
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Navigation Property 
        public ICollection<Serie>? Series { get; set; }
    }
}
