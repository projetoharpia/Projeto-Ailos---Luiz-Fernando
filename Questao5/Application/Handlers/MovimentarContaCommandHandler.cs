using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;

namespace Questao5.Application.Handlers;

public class MovimentarContaCommandHandler : IRequestHandler<MovimentarContaCommand, MovimentarContaResult>
{
    private readonly IMovimentoRepository _movimentoRepository;
    private readonly IContaCorrenteRepository _contaCorrenteRepository;
    private readonly IIdempotenciaRepository _idempotenciaRepository;

    public MovimentarContaCommandHandler(IMovimentoRepository movimentoRepository, IContaCorrenteRepository contaCorrenteRepository, IIdempotenciaRepository idempotemciaRepository)
    {
        _movimentoRepository = movimentoRepository;
        _contaCorrenteRepository = contaCorrenteRepository;
        _idempotenciaRepository = idempotemciaRepository;
    }

    public async Task<MovimentarContaResult> Handle(MovimentarContaCommand request, CancellationToken cancellationToken)
    {
        if(_idempotenciaRepository.ExisteIdempotencia(request.ChaveIdempotencia).Result) 
            return new MovimentarContaResult(Guid.Empty, "Movimentação de conta corrente já registrada!", request.Valor);

        var contaCorrente = await _contaCorrenteRepository.ObterContaCorrentePorId(request.ContaId);

        if(contaCorrente.Equals(null))
            throw new Exception("Conta corrente não encontrada.");

        if(contaCorrente.Ativo.Equals(0))
            throw new Exception("Conta corrente inativa.");

        var movimento = new Movimento(Guid.NewGuid(), contaCorrente.IdContaCorrente, DateTime.Now, char.ToUpper(request.TipoMovimento), request.Valor);
        var saldo = await _movimentoRepository.ObterSaldoContaCorrentePorMovimento(request.ContaId);
        
        if( saldo < request.Valor)
            throw new Exception("Saldo insuficiente!");
            
        await _movimentoRepository.InserirMovimento(movimento);

        await _idempotenciaRepository.RegistrarIdempotencia(request.ChaveIdempotencia, $"Conta {request.ContaId} atualizada em {request.TipoMovimento} para {request.Valor}", "Sucesso");
        return new MovimentarContaResult(movimento.IdMovimento, "Conta corrente atualizada com sucesso!", request.Valor);
    }
}
