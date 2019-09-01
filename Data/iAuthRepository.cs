using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface iAuthRepository
    {
         Task<User> Register(User user, string password);
				 Task<User> Login(string username, string password);
				 Task<bool> UserExist(string username);
    }
}