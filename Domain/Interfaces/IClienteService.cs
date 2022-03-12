using Data.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClienteService
    {
        public Task<List<Cliente>> ListClients();

        public Task<Cliente> GetClient(int id);

        public Task UpdateClient(int id, Cliente client);

        public Task CreateClient(Cliente client);

        public Task DeleteClient(int id);
    }
}
