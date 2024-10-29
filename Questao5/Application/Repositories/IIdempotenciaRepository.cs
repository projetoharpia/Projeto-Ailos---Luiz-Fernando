using Questao5.Domain.Entities;

namespace Questao5.Application.Repositories;

public interface IIdempotenciaRepository
{
    Task<bool> ExisteIdempotencia(string chaveIdempotencia);
    Task RegistrarIdempotencia(string chaveIdempotencia,string requisicao, string resultado);
}
