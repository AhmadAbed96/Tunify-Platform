using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.NewFolder;
using Tunify_Platform.Repositories.InterFace;

namespace Tunify_Platform.Repositories.Services
{
    public class UsersServices : IUsers
    {
        private readonly Tunify_DbContext _context;

        public UsersServices(Tunify_DbContext context)
        {
            _context = context;
        }
        public async Task<Users> CreateUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserById(int userId)
        {
            var getUser = await GetUserById(userId);
            _context.Entry(getUser).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<Users> UpdateUser(int Id, Users user)
        {

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Id))
                {
                    return null;
                }
            }

            return user;

        }
        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UsersId == id)).GetValueOrDefault();
        }
    }
}
