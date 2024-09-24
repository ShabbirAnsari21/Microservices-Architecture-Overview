using Microsoft.EntityFrameworkCore;
using User_Service.Entity;

namespace User_Service.Infra
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.UserTbl.FindAsync(id);
        }

        public async Task AddUser(User user)
        {
            _context.UserTbl.Add(user);

            await _context.SaveChangesAsync();
        }

        public async void DeleteUser(int id)
        {
            var user = await _context.UserTbl.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.UserTbl.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<User>> GetAllUser()
        {
            return await _context.UserTbl.ToListAsync();
        }
    }
}
