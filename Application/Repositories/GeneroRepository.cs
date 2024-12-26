using DataBase.Models;
using DataBase;
using Microsoft.EntityFrameworkCore;


namespace Application.Repositories
{
    public class GeneroRepository : GenericRepository<Genero>
    {        
        public GeneroRepository(ApplicationContext dbContext) : base(dbContext) 
        {            
        }

        public async Task<Genero> GetByNameAsync(string nombre)
        {
            return await _dbContext.Generos.SingleOrDefaultAsync(g => g.Nombre == nombre);
        }
    }
}
