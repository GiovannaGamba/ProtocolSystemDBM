namespace ProtocolSystemDBM.Models
{
    public sealed class ProtocolFollow : BaseModel
    {
        public ProtocolFollow(string actionDescription, DateTime actionDate, Guid protocolId) : base()
        {
            ActionDescription = actionDescription;
            ActionDate = actionDate;
            ProtocolId = protocolId;
        }

        public ProtocolFollow() { }

        public string ActionDescription { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public Guid ProtocolId { get; set; }

        public Protocol Protocol { get; set; }

        public void Update(ProtocolFollow protocolFollow)
        {
            ActionDescription = protocolFollow.ActionDescription;
            ActionDate = protocolFollow.ActionDate;
        }
    }
}
