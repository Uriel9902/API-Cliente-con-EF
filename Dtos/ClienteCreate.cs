using System.ComponentModel.DataAnnotations;

namespace API_Cliente_con_EF.Dtos
{
    public class ClienteCreate
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
    }
}
