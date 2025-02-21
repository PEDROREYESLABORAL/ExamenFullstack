using MediatR;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Commands.Producto;
using Productos.Application.Requests.Producto;

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly ISender _sender;
        public OrdenController(ISender sender) {
            _sender = sender;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddOrden([FromBody] AddOrdenRequest request) {
            try {
                var addProductoCommand = new AddProductoCommand(request);
                var response = await _sender.Send(addProductoCommand);
                if (response.IsSuccess)
                    return Created("", response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("/update/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProducto(int id, UpdateProductoCommand command) {
            if (id != command._model.Id)
                return BadRequest();
            var response = await _sender.Send(command);

            if (response.IsSuccess)
                return Ok(response);
            else
                return NoContent();
            //return BadRequest(response);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProducto(DeleteProductoCommand command) {
            if (command == null)
                return BadRequest();

            var response = await _sender.Send(command);

            if (response.IsSuccess)
                return Ok(response);
            else
                return NoContent();
            //return BadRequest(response);
        }


        //[HttpDelete("{id}")] 
        //public async Task<IActionResult> Delete(int id) { 
        //    await _sender.Send(new DeleteProductCommand { ProductId = id }); 
        //    return NoContent();
        //    }

    }
}
