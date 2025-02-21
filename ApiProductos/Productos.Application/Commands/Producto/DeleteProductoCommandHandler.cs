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
    public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, DeleteProductoResponse>
    {
        private readonly IProductoRepository _productoRepository;
        public DeleteProductoCommandHandler(IProductoRepository productoRepository) {
            _productoRepository = productoRepository;
        }

        public async Task<DeleteProductoResponse> Handle(DeleteProductoCommand command, CancellationToken cancellationToken) {
            if (command._model != null) {
                var response = await _productoRepository.DeleteProducto(command._model.Id);
                return new DeleteProductoResponse() { IsSuccess = response, Message = response == true ? "Product deleted successfully." : "Fail", Id = response == true ? command._model.Id : -1 };
            }
            else {
                return new DeleteProductoResponse() { IsSuccess = false, Status = "Failed", Message = "No data" };
            }
        }
    }
}
