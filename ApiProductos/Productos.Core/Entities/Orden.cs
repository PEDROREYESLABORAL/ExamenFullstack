using Productos.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Core.Entities
{
    public class Orden : BaseEntity
    {
        public int IdOrden { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaOrden { get; set; }

        public virtual ICollection<OrdenProducto> OrdenProductos { get; set; } = new List<OrdenProducto>();
    }
}
