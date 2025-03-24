using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Domain.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "No se permiten nombres tan largo, mejor cambiatelo") ]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
       
    }
}
