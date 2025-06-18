

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Catalogs
{
    [Table("TipoProducto", Schema = "cat")]
    public class TipoProducto
    {
        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tipoProductoId", Order = 0)]
        public int TipoProductoId { get; set; }
        [Column("nombre", Order = 1)]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Column("descripcion", Order = 2)]
        public string Descripcion { get; set; }
        [Column("activo", Order = 3)]
        public bool Activo { get; set; }


        public virtual ICollection<Producto> Productos { get; set; }
    }
}
