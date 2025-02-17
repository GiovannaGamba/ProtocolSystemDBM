using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Services.Interfaces
{
    public interface IProtocolService
    {
        Task<List<Protocol>> GetProtocolsAsync();
        Task<Protocol> GetProtocolByIdAsync(Guid protocolId);
        Task CreateProtocolAsync(Protocol protocol);
        Task UpdateProtocolAsync(Protocol protocol);
        Task DeleteProtocolAsync(Guid protocolId);
    }
}
