using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.InterFace
{
    public interface IUsers
    {
        object Users { get; }

        public Task<IEnumerable<Users>> GetAllUsers();

        Task<Users> GetUserById(int id);
        Task<Users> UpdateUser(int userId, Users user);
        Task DeleteUserById(int userId);
        Task<Users> CreateUser(Users user);

    }
}
