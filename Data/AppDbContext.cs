using API_Cliente_con_EF.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Cliente_con_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> x) :base(x)
        {
            
        }
        //Modelos
       public DbSet<Cliente> Cliente { get; set; }
    }
}
