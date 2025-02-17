using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.Services.Interfaces
{
    public interface IProtocolFollowService
    {
        Task<List<ProtocolFollow>> GetProtocolFollowsByProtocolIdAsync(Guid protocolId);
        Task<ProtocolFollow> GetProtocolFollowByIdAsync(Guid protocolFollowId);
        Task CreateProtocolFollowAsync(ProtocolFollow protocolFollow);
        Task UpdateProtocolFollowAsync(ProtocolFollow protocolFollow);
        Task DeleteProtocolFollowAsync(Guid protocolFollowId);
    }
}
