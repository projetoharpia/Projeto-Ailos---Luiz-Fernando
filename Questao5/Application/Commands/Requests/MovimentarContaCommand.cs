using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests;

public class MovimentarContaCommand : IRequest<MovimentarContaResult>
{
    public Guid ContaId { get; set; }
    public decimal Valor { get; set; }
    public char TipoMovimento { get; set; }
    public string ChaveIdempotencia { get; set; }

    public MovimentarContaCommand()
    {
        
    }
    
    public MovimentarContaCommand(Guid contaId, decimal valor, char tipoMovimento, string chaveIdempotencia)
    {
        ContaId = contaId;
        Valor = valor;
        TipoMovimento = tipoMovimento;
        ChaveIdempotencia = chaveIdempotencia;
    }
}
