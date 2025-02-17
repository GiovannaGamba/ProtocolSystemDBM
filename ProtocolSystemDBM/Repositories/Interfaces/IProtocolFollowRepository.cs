using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Repositories.Interfaces
{
    public interface IProtocolFollowRepository
    {
        Task<List<ProtocolFollow>> GetProtocolFollowsByProtocolIdAsync(Guid protocolId);
        Task<ProtocolFollow> GetProtocolFollowByIdAsync(Guid protocolFollowId);
        Task CreateProtocolFollowAsync(ProtocolFollow protocolFollow);
        Task UpdateProtocolFollowAsync(ProtocolFollow protocolFollow);
        Task DeleteProtocolFollowAsync(ProtocolFollow protocolFollow);
    }
}
