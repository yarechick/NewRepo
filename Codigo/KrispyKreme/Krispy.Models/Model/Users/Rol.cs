
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Users
{
    [Table("Rol", Schema ="usr")]
    public class Rol
    {
        [Key]
        [Column("rolId", Order = 0)]
        public Int16 RolId { get; set; }
        [StringLength(50)]
        [Column("nombre", Order = 1)]
        public string Nombre { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fechaModificacion", Order = 2)]
        public DateTime FechaModificacion { get; set; }
        [Required]
        [Column("activo", Order = 3)]
        public bool Activo { get; set; }
    }
}
