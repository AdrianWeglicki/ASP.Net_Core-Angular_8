using System.Threading.Tasks;

namespace DatingSite.API.Data
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0; 
        }
    } 
}