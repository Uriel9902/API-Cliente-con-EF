using API_Cliente_con_EF.Data;
using API_Cliente_con_EF.Data.Models;
using API_Cliente_con_EF.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace API_Cliente_con_EF.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<Cliente>> GetAll() => await _context.Cliente.ToListAsync();
        public async Task<Cliente> GetById(int id) => await _context.Cliente.FindAsync(id);
        public async Task<Cliente> Post(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            return cliente;
        }

        public async Task<Cliente> Patch(ClienteUpdate cliente)
        {
            var client = await GetById(cliente.Id); // Traer de la DB
            if (client == null) return null;

            // Aplicar los cambios
            client.Nombre = cliente.Nombre;
            client.Correo = cliente.Correo;
            client.Telefono = cliente.Telefono;

            _context.Cliente.Update(client); // Marcar como modificado
            return client; // Devuelve el objeto rastreado
        }
        public async Task<Cliente> Delete(int id)
        {
            var client = await GetById(id); // Traer de la DB
            if (client == null) return null;
            _context.Cliente.Remove(client); // Eliminar
            return client; // Devuelve el objeto rastreado
        }



        public async Task Save() => await _context.SaveChangesAsync();

    }
}
