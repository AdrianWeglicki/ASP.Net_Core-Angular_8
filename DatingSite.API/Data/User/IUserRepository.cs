using System.Collections.Generic;
using System.Threading.Tasks;
using DatingSite.API.Models;

namespace DatingSite.API.Data
{
    public interface IUserRepository: IGenericRepository
    {
         Task<IEnumerable<User>> GetUsers();

         Task<User> GetUser(int id);
    }
}