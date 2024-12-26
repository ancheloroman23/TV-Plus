using DataBase;
using DataBase.Models;

namespace Application.Repositories
{
    public class SerieRepository : GenericRepository<Serie>
    {        
        public SerieRepository(ApplicationContext dbContext) : base(dbContext)
        {            
        }

        public override Task<List<Serie>> GetAllWithIncludes(List<string> properties)
        {
            return base.GetAllWithIncludes(properties);
        }

        public override async Task<Serie> GetByIdAsync(int id)
        {
            var list = await GetAllWithIncludes(new List<string> { "Productora", "Genero" });
            var entity = list.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }
    }
}
