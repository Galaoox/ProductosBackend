using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ProductoService : IProductoService
    {
        private readonly ProductosDBContext _dbContext;

        public ProductoService(ProductosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Producto>> ListProductos()
        {
            return await _dbContext.Productos.Where(x => x.Disabled != 1).ToListAsync();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await FindProducto(id);
        }

        public async Task UpdateProducto(int id, Producto producto)
        {
            var productFound = await FindProducto(id);
            productFound.Nombre = producto.Nombre;
            productFound.ValorUnitario = producto.ValorUnitario;
            _dbContext.Update(productFound);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateProducto(Producto producto)
        {
            _dbContext.Add(producto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProducto(int id)
        {
            var clientFounded = await FindProducto(id);
            clientFounded.Disabled = 1;
            _dbContext.Update(clientFounded);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Producto> FindProducto(int id)
        {
            var product = await _dbContext.Productos.FirstOrDefaultAsync(c => c.Id == id && c.Disabled != 1);
            if (product == null) throw new Exception("No se encontro el producto");
            return product;
        }
    }
}
