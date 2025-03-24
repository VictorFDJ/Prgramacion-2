using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.api.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(300, ErrorMessage = "Descripcion muy larga")]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal Precio { get; set; }

    }
}
