using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.ViewModels.ProtocolFollows
{
    public class ListProtocolFollowsViewModel
    {
        public Guid Id { get; set; }
        public List<ProtocolFollow> ProtocolFollows { get; set; }
    }
}
