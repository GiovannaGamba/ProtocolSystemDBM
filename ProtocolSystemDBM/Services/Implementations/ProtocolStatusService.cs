using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Repositories.Interfaces;
using ProtocolSystemDBM.Services.Interfaces;

namespace ProtocolSystemDBM.Services.Implementations
{
    public class ProtocolStatusService : IProtocolStatusService
    {
        private readonly IProtocolStatusRepository _protocolStatusRepository;

        public ProtocolStatusService(IProtocolStatusRepository protocolStatusRepository)
        {
            _protocolStatusRepository = protocolStatusRepository;
        }

        public async Task<List<ProtocolStatus>> GetProtocolStatusesAsync()
        {
            return await _protocolStatusRepository.GetProtocolStatusesAsync();
        }

        public async Task<ProtocolStatus> GetProtocolStatusByIdAsync(Guid protocolStatusId)
        {
            return await _protocolStatusRepository.GetProtocolStatusByIdAsync(protocolStatusId);
        }

        public async Task CreateProtocolStatusAsync(ProtocolStatus protocolStatus)
        {
            await _protocolStatusRepository.CreateProtocolStatusAsync(protocolStatus);
        }

        public async Task UpdateProtocolStatusAsync(ProtocolStatus protocolStatus)
        {
            ProtocolStatus updatingProtocolStatus = await GetProtocolStatusByIdAsync(protocolStatus.Id);
            updatingProtocolStatus.Name = protocolStatus.Name;
            updatingProtocolStatus.Deleted = protocolStatus.Deleted;
            await _protocolStatusRepository.UpdateProtocolStatusAsync(updatingProtocolStatus);
        }

        public async Task DeleteProtocolStatusAsync(Guid protocolStatusId)
        {
            ProtocolStatus deletingProtocolStatus = await GetProtocolStatusByIdAsync(protocolStatusId);
            deletingProtocolStatus.Delete();

            await _protocolStatusRepository.UpdateProtocolStatusAsync(deletingProtocolStatus);
        }
    }
}
