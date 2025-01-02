using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Core.Entities
{
    public class OrdenProducto
    {
        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
