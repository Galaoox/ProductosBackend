using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Interfaces
{
    public interface IProductoService
    {
        public Task<List<Producto>> ListProducts();

        public Task<Producto> GetProduct(int id);

        public Task UpdateProduct(int id, Producto product);

        public Task CreateProduct(Producto product);

        public Task DeleteProduct(int id);
    }
}
