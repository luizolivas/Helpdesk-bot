using ChamadoDataAccessLibrary.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChamadoDataAccessLibrary.Models
{
    [Table("Chamado")]
    public class Chamado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? User  { get; set; }
        public string? Codes { get; set; }
        public StatusChamado Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public string? InternalDescription { get; set; }
        public int IdCliente { get; set; }

        public ICollection<ImageChamado> Images { get; set; } = new List<ImageChamado>();

    }
}
