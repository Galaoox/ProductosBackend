using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductoService
    {
        public Task<List<Producto>> ListProductos();

        public Task<Producto> GetProducto(int id);

        public Task UpdateProducto(int id, Producto producto);

        public Task CreateProducto(Producto producto);

        public Task DeleteProducto(int id);
    }
}
