using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IVentaService
    {
        public Task<List<Venta>> ListVenta();

        public Task<Venta> GetVenta(int id);

        public Task UpdateVenta(int id, Venta venta);

        public Task CreateVenta(Venta venta);

        public Task DeleteVenta(int id);
    }
}
