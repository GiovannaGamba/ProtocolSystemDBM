namespace ProtocolSystemDBM.Models
{
    public sealed class ProtocolStatus : BaseModel
    {
        public ProtocolStatus(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
        public bool Deleted { get; set; } = false;

        public List<Protocol> Protocols { get; set; }


        public void Delete()
        {
            Deleted = true;
        }
    }
}
