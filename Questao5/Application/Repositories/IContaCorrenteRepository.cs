using System;
using Questao5.Domain.Entities;

namespace Questao5.Application.Repositories;

public interface IContaCorrenteRepository
{
    Task<ContaCorrente> ObterContaCorrentePorId(Guid id);
}
