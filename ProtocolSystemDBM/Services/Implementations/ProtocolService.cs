using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;
using ProtocolSystemDBM.Services.Interfaces;

namespace ProtocolSystemDBM.Services.Implementations
{
    public class ProtocolService : IProtocolService
    {
        private readonly IProtocolRepository _protocolRepository;

        public ProtocolService(IProtocolRepository protocolRepository)
        {
            _protocolRepository = protocolRepository;
        }

        public async Task<List<Protocol>> GetProtocolsAsync()
        {
            return await _protocolRepository.GetProtocolsAsync();
        }

        public async Task<Protocol> GetProtocolByIdAsync(Guid protocolId)
        {
            return await _protocolRepository.GetProtocolByIdAsync(protocolId);
        }

        public async Task CreateProtocolAsync(Protocol protocol)
        {
            await _protocolRepository.CreateProtocolAsync(protocol);
        }

        public async Task UpdateProtocolAsync(Protocol protocol)
        {
            Protocol updatingProtocol = await GetProtocolByIdAsync(protocol.Id);
            updatingProtocol.Update(protocol);

            await _protocolRepository.UpdateProtocolAsync(updatingProtocol);
        }

        public async Task DeleteProtocolAsync(Guid protocolId)
        {
            Protocol deletingProtocol = await GetProtocolByIdAsync(protocolId);
            await _protocolRepository.DeleteProtocolAsync(deletingProtocol);
        }
    }
}
