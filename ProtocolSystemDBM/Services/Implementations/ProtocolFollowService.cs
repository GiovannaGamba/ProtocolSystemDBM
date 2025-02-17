using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;
using ProtocolSystemDBM.Services.Interfaces;

namespace ProtocolSystemDBM.Services.Implementations
{
    public class ProtocolFollowService : IProtocolFollowService
    {
        private readonly IProtocolFollowRepository _protocolFollowRepository;
        private readonly IProtocolService _protocolService;

        public ProtocolFollowService(IProtocolFollowRepository protocolFollowRepository, IProtocolService protocolService)
        {
            _protocolFollowRepository = protocolFollowRepository;
            _protocolService = protocolService;
        }

        public async Task<List<ProtocolFollow>> GetProtocolFollowsByProtocolIdAsync(Guid protocolId)
        {
            return await _protocolFollowRepository.GetProtocolFollowsByProtocolIdAsync(protocolId);
        }

        public async Task<ProtocolFollow> GetProtocolFollowByIdAsync(Guid protocolFollowId)
        {
            return await _protocolFollowRepository.GetProtocolFollowByIdAsync(protocolFollowId);
        }

        public async Task CreateProtocolFollowAsync(ProtocolFollow protocolFollow)
        {
            protocolFollow.Protocol = await _protocolService.GetProtocolByIdAsync(protocolFollow.ProtocolId);
            await _protocolFollowRepository.CreateProtocolFollowAsync(protocolFollow);
        }

        public async Task UpdateProtocolFollowAsync(ProtocolFollow protocolFollow)
        {
            ProtocolFollow updatingProtocolFollow = await GetProtocolFollowByIdAsync(protocolFollow.Id);
            updatingProtocolFollow.Update(protocolFollow);

            await _protocolFollowRepository.UpdateProtocolFollowAsync(updatingProtocolFollow);
        }

        public async Task DeleteProtocolFollowAsync(Guid protocolFollowId)
        {
            ProtocolFollow deletingProtocolFollow = await GetProtocolFollowByIdAsync(protocolFollowId);
            await _protocolFollowRepository.DeleteProtocolFollowAsync(deletingProtocolFollow);
        }
    }
}
