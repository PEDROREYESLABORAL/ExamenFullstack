using MediatR;
using Productos.Application.Interfaces;
using Productos.Application.Responses.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Commands.Producto
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, UpdateProductoResponse>
    {
        private readonly IProductoRepository _productoRepository;
        public UpdateProductoCommandHandler(IProductoRepository productoRepository) {
            _productoRepository = productoRepository;
        }

        public async Task<UpdateProductoResponse> Handle(UpdateProductoCommand command, CancellationToken cancellationToken) {
            if (command._model != null) {
                Core.Entities.Producto producto = new Core.Entities.Producto() {
                    Id = command._model.Id,
                    Nombre = command._model.Nombre,
                    Descripcion = command._model.Descripcion,
                    Precio = command._model.Precio,
                    Stock = command._model.Stock
                };
                var response = await _productoRepository.UpdateProducto(producto);
                return new UpdateProductoResponse() { IsSuccess = response, Message = response == true ? "Product updated successfully." : "Fail", Id = response == true ? producto.Id : -1 };
            }
            else {
                return new UpdateProductoResponse() { IsSuccess = false, Status = "Failed", Message = "No data" };
            }
        }
    }
}
