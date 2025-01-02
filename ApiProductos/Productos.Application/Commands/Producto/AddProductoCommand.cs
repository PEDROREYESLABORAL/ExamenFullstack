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
       public class AddProductoCommand : IRequest<AddProductoResponse>
    {
        public AddProductoRequest _model { get; set; }
        public AddProductoCommand(AddProductoRequest model) {
            _model = model;
        }
    }
}
