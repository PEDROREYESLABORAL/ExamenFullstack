using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Requests.Producto
{
    public class AddProductoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

    }
}
