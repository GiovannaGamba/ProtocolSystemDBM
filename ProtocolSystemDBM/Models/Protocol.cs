namespace ProtocolSystemDBM.Models
{
    public sealed class Protocol : BaseModel
    {
        public Protocol(Guid id, string title, string description, DateTime openingDate, DateTime? closingDate, Guid userId, Guid protocolStatusId)
        {
            Id = id;
            Title = title;
            Description = description;
            OpeningDate = openingDate;
            ClosingDate = closingDate;
            UserId = userId;
            ProtocolStatusId = protocolStatusId;
        }

        public Protocol() { }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OpeningDate { get; set; } = DateTime.Now;
        public DateTime? ClosingDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ProtocolStatusId { get; set; }

        public User User { get; set; }
        public ProtocolStatus ProtocolStatus { get; set; }
        public ICollection<ProtocolFollow> ProtocolFollows { get; set; }

        public void Update(Protocol protocol)
        {
            Title = protocol.Title;
            Description = protocol.Description;
            OpeningDate = protocol.OpeningDate;
            ClosingDate = protocol.ClosingDate;
            UserId = protocol.UserId;
            ProtocolStatusId = protocol.ProtocolStatusId;
        }
    }
}
