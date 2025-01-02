//using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Commands.Producto;
using Productos.Application.Requests.Producto;


namespace ApiProductos.Controllers
{

    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ISender _sender;
        public ProductoController(ISender sender) {
            _sender = sender;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddProduct([FromBody] AddProductoRequest request) {
            try {
                var addProductoCommand = new AddProductoCommand(request);
                var response = await _sender.Send(addProductoCommand);
                if (response.IsSucceess)
                    return Created("", response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Route("/update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(int id, UpdateProductoCommand command) {
            if (id != command._model.Id)
                return BadRequest();
            var product = await _sender.Send(command);
            return NoContent();
        }
        //[HttpDelete("{id}")] 
        //public async Task<IActionResult> Delete(int id) { 
        //    await _sender.Send(new DeleteProductCommand { ProductId = id }); 
        //    return NoContent();
        //    }

    }
}

