using MediatR;
using Productos.Application.Interfaces;
using Productos.Application.Responses.Producto;
using Productos.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Commands.Producto
{


    public class AddProductoCommandHandler : IRequestHandler<AddProductoCommand, AddProductoResponse>
    {
        private readonly IProductoRepository _productoRepository;
        public AddProductoCommandHandler(IProductoRepository productoRepository) {
            _productoRepository = productoRepository;
        }

        public async Task<AddProductoResponse> Handle(AddProductoCommand command, CancellationToken cancellationToken) {
            if (command._model != null) {
                Core.Entities.Producto producto = new Core.Entities.Producto() {
                    Nombre = command._model.Nombre,
                    Descripcion = command._model.Descripcion,
                    Precio = command._model.Precio,
                    Stock = command._model.Stock
                };
                var response = await _productoRepository.AddProducto(producto);
                return new AddProductoResponse() { IsSucceess = response, Message = response == true ? "Succeess" : "Fail", IdCreated = response == true ? producto.Id : -1 };
            }
            else {
                return new AddProductoResponse() { IsSucceess = false, Status = "Failed", Message = "No data" };
            }
        }
    }
}
