using ProtocolSystemDBM.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtocolSystemDBM.ViewModels.ProtocolStatuses
{
    public abstract class ProtocolStatusViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Name { get; set; } = string.Empty;

        public bool Deleted { get; set; } = false;

        public virtual ProtocolStatus FromViewModelToEntity()
        {
            return new ProtocolStatus(Name) { Deleted = Deleted };
        }
    }
}
