using Questao5.Domain.Entities;

namespace Questao5.Application.Repositories;

public interface IMovimentoRepository
{
    Task<decimal> ObterSaldoContaCorrentePorMovimento(Guid idContaCorrente);
    Task InserirMovimento(Movimento movimento);
}
