using System.Threading.Tasks;
using DatingSite.API.Models;

namespace DatingSite.API.Data
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Method to login user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Object User</returns>
         Task<User> Login(string username, string password);

         /// <summary>
         /// MEthod to register new user
         /// </summary>
         /// <param name="user"></param>
         /// <param name="password"></param>
         /// <returns>Object User</returns>
         Task<User> Register(User user, string password);

        /// <summary>
        /// Method to check if username exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns>boolean</returns>
         Task<bool> UserExists(string username);

    }
}