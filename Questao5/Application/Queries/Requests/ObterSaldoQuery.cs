using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests;

public class ObterSaldoQuery : IRequest<ObterSaldoResult>
{
    public Guid ContaId { get; set; }

    public ObterSaldoQuery()
    {
        
    }
    
    public ObterSaldoQuery(Guid contaId)
    {
        ContaId = contaId;       
    }
}
