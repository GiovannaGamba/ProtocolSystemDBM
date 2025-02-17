using Microsoft.EntityFrameworkCore;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;

namespace ProtocolSystemDBM.Repositories.Implementations
{
    public class ProtocolRepository : IProtocolRepository
    {
        private readonly ProtocolSystemDbContext _dbContext;

        public ProtocolRepository(ProtocolSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Protocol>> GetProtocolsAsync()
        {
            return await _dbContext.Protocols
                .Include(p => p.User)
                .Include(p => p.ProtocolStatus)
                .ToListAsync();
        }

        public async Task<Protocol> GetProtocolByIdAsync(Guid protocolId)
        {
            return await _dbContext.Protocols
                .Include(p => p.User)
                .Include(p => p.ProtocolStatus)
                .FirstOrDefaultAsync(p => p.Id == protocolId);
        }

        public async Task CreateProtocolAsync(Protocol protocol)
        {
            await _dbContext.Protocols.AddAsync(protocol);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProtocolAsync(Protocol protocol)
        {
            _dbContext.Protocols.Update(protocol);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProtocolAsync(Protocol protocol)
        {
            _dbContext.Protocols.Remove(protocol);
            await _dbContext.SaveChangesAsync();
        }
    }
}
