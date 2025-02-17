using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.ViewModels.Protocols
{
    public class UpdateProtocolViewModel : ProtocolViewModel
    {
        public Guid Id { get; set; }


        public override Protocol FromViewModelToEntity()
        {
            return new Protocol(Id, Title, Description, OpeningDate, ClosingDate, UserId, ProtocolStatusId);
        }

        public static UpdateProtocolViewModel FromEntityToViewModel(Protocol protocol, List<User> users, List<ProtocolStatus> protocolStatuses)
        {
            return new UpdateProtocolViewModel
            {
                Id = protocol.Id,
                Title = protocol.Title,
                Description = protocol.Description,
                OpeningDate = protocol.OpeningDate,
                ClosingDate = protocol.ClosingDate,
                ProtocolStatusId = protocol.ProtocolStatusId,
                UserId = protocol.UserId,
                Users = users,
                ProtocolStatuses = protocolStatuses
            };
        }
    }
}
