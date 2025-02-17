using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Repositories.Interfaces
{
    public interface IProtocolRepository
    {
        Task<List<Protocol>> GetProtocolsAsync();
        Task<Protocol> GetProtocolByIdAsync(Guid protocolId);
        Task CreateProtocolAsync(Protocol protocol);
        Task UpdateProtocolAsync(Protocol protocol);
        Task DeleteProtocolAsync(Protocol protocol);
    }
}
