using ProtocolSystemDBM.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtocolSystemDBM.ViewModels.ProtocolFollows
{
    public class ProtocolFollowViewModel
    {
        [Required(ErrorMessage = "A descrição da ação é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        [MinLength(6, ErrorMessage = "A descrição deve ter no mínimo 6 caracteres.")]
        public string ActionDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data da ação é obrigatória.")]
        public DateTime ActionDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O ID do protocolo é obrigatório.")]
        public Guid ProtocolId { get; set; }

        public virtual ProtocolFollow FromViewModelToEntity()
        {
            return new ProtocolFollow(ActionDescription, ActionDate, ProtocolId);
        }
    }
}
