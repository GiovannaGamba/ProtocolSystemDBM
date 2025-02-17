using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.ViewModels.ProtocolStatuses
{
    public class UpdateProtocolStatusViewModel : ProtocolStatusViewModel
    {
        public Guid Id { get; set; }

        public override ProtocolStatus FromViewModelToEntity()
        {
            return new ProtocolStatus(Name) { Id = Id, Deleted = Deleted };
        }

        public static UpdateProtocolStatusViewModel FromEntityToViewModel(ProtocolStatus protocolStatus)
        {
            return new UpdateProtocolStatusViewModel
            {
                Id = protocolStatus.Id,
                Name = protocolStatus.Name,
                Deleted = protocolStatus.Deleted
            };
        }
    }
}
