using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaCorrenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{id}/Movimentar")]
        public async Task<IActionResult> MovimentarConta(string id, [FromBody] MovimentarContaCommand command)
        {
            if (id.ToString().ToUpper() != command.ContaId.ToString().ToUpper())
                return BadRequest("Id informado na url diferente do id informado no body");
            
            var result = await _mediator.Send(command);
            
            if (result.Equals(null))
            {
                return BadRequest("Movimentação não realizada.");
            }
            
            return Ok(result);
        }

        [HttpGet("{id}/Saldo")]
        public async Task<IActionResult> ObterSaldo(string id)
        {
            var query = new ObterSaldoQuery(Guid.Parse(id));
            var saldo = await _mediator.Send(query);

            if (saldo.Equals(null))
            {
                return NotFound("Conta corrente não encontrada.");
            }

            return Ok(saldo);
        }
    }
}
