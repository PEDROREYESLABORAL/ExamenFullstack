using Microsoft.Data.SqlClient;
using Productos.Application.Interfaces;
using Productos.Core.Entities;
using Productos.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosContext _context;


        public ProductoRepository(ProductosContext context) {
            _context = context;
        }

        public async Task<bool> AddProducto(Producto model) {
            if (model != null) {
                try {
                    await _context.Producto.AddAsync(model);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (SqlException se) {
                    return false;
                }
                catch (Exception e) {
                    return false;
                }
            }
            else
                return false;
        }

        public async Task<bool> DeleteProducto(int idProducto) {
            try {
                var producto = await _context.Producto.FindAsync(idProducto);
                if (producto != null) {
                    _context.Producto.Remove(producto);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch (Exception e) {
                return false;
            }
        }

        public async Task<bool> UpdateProducto(Producto model) {
            if (model != null) {
                try {
                    _context.Producto.Update(model);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e) {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
}
