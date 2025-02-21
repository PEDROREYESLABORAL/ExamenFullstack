using Productos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Interfaces
{
    public interface IProductoRepository
    {
        public Task<bool> AddProducto(Producto model);
        public Task<bool> UpdateProducto(Producto model);
        public Task<bool> DeleteProducto(int idProducto);


    }
}
