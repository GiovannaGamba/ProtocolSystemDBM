using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Repositories.Interfaces
{
    public interface IProtocolStatusRepository
    {
        Task<List<ProtocolStatus>> GetProtocolStatusesAsync();
        Task<ProtocolStatus> GetProtocolStatusByIdAsync(Guid protocolStatusId);
        Task CreateProtocolStatusAsync(ProtocolStatus protocolStatus);
        Task UpdateProtocolStatusAsync(ProtocolStatus protocolStatus);
    }
}
