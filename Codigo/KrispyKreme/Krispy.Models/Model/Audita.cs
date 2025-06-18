

using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model
{
    public abstract class Audita
    {
        [Column("creadoPor")]
        public string CreadoPor { get; set; }
        [Column("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [Column("modificadoPor")]
        public string ModificadoPor { get; set; }
        [Column("fechaModificacion")]
        public DateTime? FechaModificacion { get; set; } 
    }
}
