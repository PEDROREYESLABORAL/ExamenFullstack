﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Responses.Producto
{
    public class DeleteProductoResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int Id { get; set; }
    }
}
