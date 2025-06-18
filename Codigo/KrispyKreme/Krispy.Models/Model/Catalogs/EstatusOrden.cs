using Krispy.Models.Model.Transactional;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Catalogs
{
    [Table("EstatusOrden", Schema = "cat")]
    public class EstatusOrden
    {
        public EstatusOrden()
        {
            Ordenes = new HashSet<Orden>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("estatusOrdenId", Order = 0)]
        public int EstatusOrdenId { get; set; }
        [Column("nombre", Order = 1)]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Column("descipcion", Order = 2)]
        public string Descripcion { get; set; }

        [Column("activo", Order = 3)]
        public bool Activo { get; set; }


        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
