using ProtocolSystemDBM.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtocolSystemDBM.ViewModels.Protocols
{
    public abstract class ProtocolViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, ErrorMessage = "O título não pode exceder 200 caracteres.")]
        [MinLength(3, ErrorMessage = "O título deve ter no mínimo 3 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(6, ErrorMessage = "A descrição deve ter no mínimo 6 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de abertura é obrigatória.")]
        public DateTime OpeningDate { get; set; } = DateTime.Now;

        public DateTime? ClosingDate { get; set; }

        [Required(ErrorMessage = "O usuário responsável é obrigatório.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O status do protocolo é obrigatório.")]
        public Guid ProtocolStatusId { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        public List<ProtocolStatus> ProtocolStatuses { get; set; } = new List<ProtocolStatus>();

        public virtual Protocol FromViewModelToEntity()
        {
            return new Protocol
            {
                Title = Title,
                Description = Description,
                OpeningDate = OpeningDate,
                ClosingDate = ClosingDate,
                UserId = UserId,
                ProtocolStatusId = ProtocolStatusId
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClosingDate.HasValue && ClosingDate < OpeningDate)
            {
                yield return new ValidationResult(
                    "A data de fechamento deve ser maior ou igual a data de abertura.",
                    [nameof(ClosingDate)]
                );
            }
        }
    }
}
