using Krispy.Models.Model.Transactional;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Catalogs
{
    [Table("MetodoPago", Schema = "cat")]
    public class MetodoPago
    {
        public MetodoPago()
        {
            Ordenes = new HashSet<Orden>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("metodoPagoId", Order = 0)]
        public int MetodoPagoId { get; set; }
        [Column("nombre", Order = 1)]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Column("descripcion", Order = 2)]
        public string Descripcion { get; set; }

        [Column("activo", Order = 3)]
        public bool Activo { get; set; }


        public virtual ICollection<Orden> Ordenes { get; set; }

    }
}
