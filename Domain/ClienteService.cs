using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models;
using Data.Models;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public  class ClienteService: IClienteService
    {
        private  readonly ProductosDBContext _dbContext;

       public ClienteService(ProductosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<List<Cliente>> ListClients()
        {
            return await _dbContext.Clientes.Where(x => x.Disabled != 1).ToListAsync();
        }

        public async Task<Cliente> GetClient(int id)
        {
            return await FindClient(id);
        }

        public async Task UpdateClient(int id, Cliente client)
        {
            var clientFounded = await FindClient(id);
            clientFounded.Telefono = client.Telefono;
            clientFounded.Cedula = client.Cedula;
            clientFounded.Nombre = client.Nombre;
            clientFounded.Apellido = client.Apellido;
            _dbContext.Update(clientFounded);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateClient(Cliente client)
        {
            _dbContext.Add(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClient(int id)
        {
            var clientFounded = await FindClient(id);
            clientFounded.Disabled = 1;
            _dbContext.Update(clientFounded);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Cliente> FindClient(int id)
        {
            var clientFounded = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id && c.Disabled != 1);
            if (clientFounded == null) throw new Exception("No se encontro el cliente");
            return clientFounded;
        }
    }
}
