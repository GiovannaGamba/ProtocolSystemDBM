using ProtocolSystemDBM.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtocolSystemDBM.ViewModels.Users
{
    public abstract class UserViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone não é válido.")]
        [MinLength(11, ErrorMessage = "O telefone deve ter no mínimo 11 caracteres.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [MinLength(10, ErrorMessage = "O endereço deve ter no mínimo 10 caracteres.")]
        public string Address { get; set; } = string.Empty;

        public virtual User FromViewModelToEntity()
        {
            return new User(Name, Email, Phone, Address);
        }
    }
}
