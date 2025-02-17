using Microsoft.EntityFrameworkCore;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;

namespace ProtocolSystemDBM.Repositories.Implementations
{
    public class ProtocolFollowRepository : IProtocolFollowRepository
    {
        private readonly ProtocolSystemDbContext _dbContext;

        public ProtocolFollowRepository(ProtocolSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProtocolFollow>> GetProtocolFollowsByProtocolIdAsync(Guid protocolId)
        {
            return await _dbContext.ProtocolFollows.Where(protocolFollow => protocolFollow.ProtocolId == protocolId).ToListAsync();
        }

        public async Task<ProtocolFollow> GetProtocolFollowByIdAsync(Guid protocolFollowId)
        {
            return await _dbContext.ProtocolFollows.FirstAsync(protocolFollow => protocolFollow.Id == protocolFollowId);
        }

        public async Task CreateProtocolFollowAsync(ProtocolFollow protocolFollow)
        {
            await _dbContext.ProtocolFollows.AddAsync(protocolFollow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProtocolFollowAsync(ProtocolFollow protocolFollow)
        {
            _dbContext.ProtocolFollows.Update(protocolFollow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProtocolFollowAsync(ProtocolFollow protocolFollow)
        {
            _dbContext.ProtocolFollows.Remove(protocolFollow);
            await _dbContext.SaveChangesAsync();
        }
    }
}
