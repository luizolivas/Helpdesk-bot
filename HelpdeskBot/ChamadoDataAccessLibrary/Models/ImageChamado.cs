using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChamadoDataAccessLibrary.Models
{
    public class ImageChamado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Caminho { get; set; }

        public string Tipo { get; set; }

        public DateTime DataUpload { get; set; }

        // Chave estrangeira para Chamado
        public int ChamadoId { get; set; }
        [ForeignKey("ChamadoId")]
        public Chamado Chamado { get; set; }
    }
}
