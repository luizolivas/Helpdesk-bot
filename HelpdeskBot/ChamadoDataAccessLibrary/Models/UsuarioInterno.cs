using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChamadoDataAccessLibrary.Enum;

namespace ChamadoDataAccessLibrary.Models
{
    public class UsuarioInterno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
