using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Application.Repositories;

namespace Questao5.Application.Handlers;

public class ObterSaldoQueryHandler : IRequestHandler<ObterSaldoQuery, ObterSaldoResult>
{
    private readonly IContaCorrenteRepository _contaCorrenteRepository;
    private readonly IMovimentoRepository _movimentoRepository;
    public ObterSaldoQueryHandler(IContaCorrenteRepository contaCorrenteRepository, IMovimentoRepository movimentoRepository)
    {
        _contaCorrenteRepository = contaCorrenteRepository;
        _movimentoRepository = movimentoRepository;
    }

    public async Task<ObterSaldoResult> Handle(ObterSaldoQuery request, CancellationToken cancellationToken)
    {
        var contaCorrente = await _contaCorrenteRepository.ObterContaCorrentePorId(request.ContaId);
        var saldoContaCorrente = await _movimentoRepository.ObterSaldoContaCorrentePorMovimento(request.ContaId);

        if(contaCorrente == null)
            return new ObterSaldoResult(0, null, "Conta corrente não encontrada.");

        return new ObterSaldoResult(saldoContaCorrente, contaCorrente.Nome, "Consulta realizada com sucesso.");
    }
}
