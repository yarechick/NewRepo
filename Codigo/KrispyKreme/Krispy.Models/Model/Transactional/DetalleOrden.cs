using Krispy.Models.Model.Catalogs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Transactional
{
    [Table("DetalleOrden", Schema = "trn")]
    public class DetalleOrden 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("detalleOrdenId", Order = 0)]
        public int DetalleOrdenId { get; set; }
        [Column("ordenId", Order = 1)]
        public int OrdenId { get; set; }
        [Column("productoId", Order = 2)]
        public int ProductoId { get; set; }
        [Column("cantidad", Order = 3)]
        public required int Cantidad { get; set; }
        [Column("precioUnitario", Order = 4)]
        public required decimal PrecioUnitario { get; set; }
        [Column("subTotal", Order = 5)]
        public required decimal SubTotal { get; set; }


        [ForeignKey("OrdenId")]
        public virtual Orden Orden { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }



    }
}
