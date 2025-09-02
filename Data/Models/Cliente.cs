using System.ComponentModel.DataAnnotations;

namespace API_Cliente_con_EF.Data.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Telefono { get; set; }
    }
}
