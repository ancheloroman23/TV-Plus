using DataBase.Models;
using DataBase;
using Microsoft.EntityFrameworkCore;


namespace Application.Repositories
{
    public class ProductoraRepository : GenericRepository<Productora>
    {        
        public ProductoraRepository(ApplicationContext dbContext) : base(dbContext)
        {            
        }


        public async Task<Productora> GetByNameAsync(string nombre)
        {
            return await _dbContext.Productoras.SingleOrDefaultAsync(p => p.Nombre == nombre);
        }
    }
}
