using MediatR;
using Productos.Application.Requests.Producto;
using Productos.Application.Responses.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Commands.Producto
{
    public class DeleteProductoCommand : IRequest<DeleteProductoResponse>
    {
        public DeleteProductoRequest _model { get; set; }
        public DeleteProductoCommand(DeleteProductoRequest model) {
            _model = model;
        }

    }
}
