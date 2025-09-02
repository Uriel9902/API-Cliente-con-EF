using System.ComponentModel.DataAnnotations;

namespace API_Cliente_con_EF.Dtos
{
    public class ClienteUpdate : ClienteCreate
    {
        [Required]
        public int Id { get; set; }

    }
}
