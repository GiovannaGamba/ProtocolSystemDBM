using Microsoft.EntityFrameworkCore;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;

namespace ProtocolSystemDBM.Repositories.Implementations
{
    public class ProtocolStatusRepository : IProtocolStatusRepository
    {
        private readonly ProtocolSystemDbContext _dbContext;

        public ProtocolStatusRepository(ProtocolSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProtocolStatus>> GetProtocolStatusesAsync()
        {
            return await _dbContext.ProtocolStatuses.Where(protocolStatus => protocolStatus.Deleted == false).ToListAsync();
        }

        public async Task<ProtocolStatus> GetProtocolStatusByIdAsync(Guid protocolStatusId)
        {
            return await _dbContext.ProtocolStatuses.FirstAsync(status => status.Id == protocolStatusId);
        }

        public async Task CreateProtocolStatusAsync(ProtocolStatus protocolStatus)
        {
            await _dbContext.ProtocolStatuses.AddAsync(protocolStatus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProtocolStatusAsync(ProtocolStatus protocolStatus)
        {
            _dbContext.ProtocolStatuses.Update(protocolStatus);
            await _dbContext.SaveChangesAsync();
        }
    }
}
