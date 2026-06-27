using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosApp.Api.Commands;

namespace PedidosApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController (IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PedidoCreateCommand command)
        {
            await mediator.Send(command);
            return Ok(new {mensagem = "Pedido criado com sucesso!"});
        }
        [HttpPatch]
        public async Task<IActionResult> PatchAsync([FromBody] PedidoUpdateCommand command)
        {
            await mediator.Send(command);
            return Ok(new {mensagem = "Pedido atualizado com sucesso!"});
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id) 
        {
            var command = new PedidoDeleteCommand {Id = id };
            await mediator.Send(command);
            return Ok(new {mensagem = "Pedido deletado com sucesso!" });
        }
    }
}
