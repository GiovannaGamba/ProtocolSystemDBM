using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.ViewModels.ProtocolFollows
{
    public class UpdateProtocolFollowViewModel : ProtocolFollowViewModel
    {
        public Guid Id { get; set; }

        public override ProtocolFollow FromViewModelToEntity()
        {
            return new ProtocolFollow(ActionDescription, ActionDate, ProtocolId) { Id = Id };
        }

        public static UpdateProtocolFollowViewModel FromEntityToViewModel(ProtocolFollow protocolFollow)
        {
            return new UpdateProtocolFollowViewModel
            {
                Id = protocolFollow.Id,
                ProtocolId = protocolFollow.ProtocolId,
                ActionDescription = protocolFollow.ActionDescription,
                ActionDate = protocolFollow.ActionDate
            };
        }
    }
}
