using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Services.Interfaces
{
    public interface IProtocolStatusService
    {
        Task<List<ProtocolStatus>> GetProtocolStatusesAsync();
        Task<ProtocolStatus> GetProtocolStatusByIdAsync(Guid protocolStatusId);
        Task CreateProtocolStatusAsync(ProtocolStatus protocolStatus);
        Task UpdateProtocolStatusAsync(ProtocolStatus protocolStatus);
        Task DeleteProtocolStatusAsync(Guid protocolStatusId);
    }
}
