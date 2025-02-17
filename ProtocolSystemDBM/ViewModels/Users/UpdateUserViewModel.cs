using ProtocolSystemDBM.Models;

namespace ProtocolSystemDBM.ViewModels.Users
{
    public class UpdateUserViewModel : UserViewModel
    {
        public Guid Id { get; set; }


        public override User FromViewModelToEntity()
        {
            return new User(Id, Name, Email, Phone, Address);
        }

        public static UpdateUserViewModel FromEntityToViewModel(User user)
        {
            return new UpdateUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address
            };
        }
    }
}
