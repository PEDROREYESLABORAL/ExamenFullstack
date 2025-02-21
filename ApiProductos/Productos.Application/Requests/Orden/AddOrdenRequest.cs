using Productos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Requests.Orden
{
    public class AddOrdenRequest
    {
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Productos.Core.Entities.Producto> Productos { get; set; }
        
    }
}
