using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClienteService
    {
        public Task<List<Cliente>> ListClientes();

        public Task<Cliente> GetCliente(int id);

        public Task UpdateCliente(int id, Cliente cliente);

        public Task CreateCliente(Cliente cliente);

        public Task DeleteCliente(int id);
    }
}
