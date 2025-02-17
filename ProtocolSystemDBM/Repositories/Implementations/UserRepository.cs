using Microsoft.EntityFrameworkCore;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;

namespace ProtocolSystemDBM.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ProtocolSystemDbContext _dbContext;

        public UserRepository(ProtocolSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FirstAsync(user => user.Id == userId);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
