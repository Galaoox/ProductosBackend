using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<Producto>> ListProducts()
        {
            return await _dbContext.Productos.Where(x => x.Disabled != 1).ToListAsync();
        }

        public async Task<Producto> GetProduct(int id)
        {
            return await FindProduct(id);
        }

        public async Task UpdateProduct(int id, Producto product)
        {
            var productFound = await FindProduct(id);
            productFound.Nombre = product.Nombre;
            productFound.ValorUnitario = product.ValorUnitario;
            _dbContext.Update(productFound);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateProduct(Producto product)
        {
            _dbContext.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var clientFounded = await FindProduct(id);
            clientFounded.Disabled = 1;
            _dbContext.Update(clientFounded);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Producto> FindProduct(int id)
        {
            var product = await _dbContext.Productos.FirstOrDefaultAsync(c => c.Id == id && c.Disabled != 1);
            if (product == null) throw new Exception("No se encontro el producto");
            return product;
        }
    }
}
