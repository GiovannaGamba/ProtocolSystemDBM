namespace ProtocolSystemDBM.Models
{
    public sealed class User : BaseModel
    {
        public User(string name, string email, string phone, string address) : base()
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public User(Guid id, string name, string email, string phone, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public User() { }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public List<Protocol> Protocols { get; set; }

        public void Update(User user)
        {
            Name = user.Name;
            Email = user.Email;
            Phone = user.Phone;
            Address = user.Address;
        }
    }
}
