
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Catalogs
{
    [Table("Producto", Schema ="cat")]
    public class Producto
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("productoId", Order =0)]
        public int ProductoId { get; set; }
        [Column("nombre", Order = 1)]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Column("descripcion", Order = 2)]
        public string Descripcion { get;set; }
        [Column("precio", Order = 3)]
        public decimal Precio { get; set; }
        [Column("tipoProductoId", Order = 4)] 
        public int TipoProductoId { get; set; }

        [Column("disponible", Order = 5)] 
        public bool Disponible { get; set; }

        [Column("activo", Order = 6)]
        public bool Activo { get; set; }


        [ForeignKey("TipoProductoId")]
        public virtual TipoProducto TipoProducto { get; set; }

    }
}
