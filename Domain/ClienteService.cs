using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly ProductosDBContext _dbContext;

        public ClienteService(ProductosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> ListClientes()
        {
            return await _dbContext.Clientes.Where(x => x.Disabled != 1).ToListAsync();
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await FindCliente(id);
        }

        public async Task UpdateCliente(int id, Cliente client)
        {
            var clientFound = await FindCliente(id);
            clientFound.Telefono = client.Telefono;
            clientFound.Cedula = client.Cedula;
            clientFound.Nombre = client.Nombre;
            clientFound.Apellido = client.Apellido;
            _dbContext.Update(clientFound);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateCliente(Cliente client)
        {
            _dbContext.Add(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCliente(int id)
        {
            var clientFounded = await FindCliente(id);
            clientFounded.Disabled = 1;
            _dbContext.Update(clientFounded);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Cliente> FindCliente(int id)
        {
            var clientFound = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id && c.Disabled != 1);
            if (clientFound == null) throw new Exception("No se encontro el cliente");
            return clientFound;
        }
    }
}
