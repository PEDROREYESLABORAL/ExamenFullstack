using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Responses.Producto
{
    public class AddProductoResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public bool IsSucceess { get; set; }
        public int IdCreated { get; set; }
    }
}
