using System;
using System.Data;
using Dapper;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Repositories;

public class ContaCorrenteRepository : IContaCorrenteRepository
{
    private readonly IDbConnection _dbConnection;
    public ContaCorrenteRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<ContaCorrente> ObterContaCorrentePorId(Guid id)
    {
        var sql = @"SELECT idcontacorrente AS IdContaCorrente, 
                        numero AS Numero, 
                        nome AS Nome, 
                        ativo AS Ativo
                    FROM contacorrente 
                    WHERE idcontacorrente = @Id";
        
        var contaCorrente = await _dbConnection.QueryFirstOrDefaultAsync<dynamic>(sql, new { Id = id });
        
        if (contaCorrente != null)
        {
            return new ContaCorrente(
                Guid.Parse(contaCorrente.IdContaCorrente),
                (int)contaCorrente.Numero,
                contaCorrente.Nome.ToString(),
                (long)contaCorrente.Ativo                  
            );
        }
        
        return null;
    }
}
