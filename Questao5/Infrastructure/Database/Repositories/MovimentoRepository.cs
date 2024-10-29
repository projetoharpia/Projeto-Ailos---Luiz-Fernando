using System.Data;
using System.Data.Common;
using System.Security.Principal;
using Dapper;
using Questao5.Application.Repositories;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Repositories;

public class MovimentoRepository : IMovimentoRepository
{
    private readonly IDbConnection _dbConnection;

    public MovimentoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<decimal> ObterSaldoContaCorrentePorMovimento(Guid idContaCorrente)
    {
        var sql = @"select 
                        SUM(CASE WHEN tipomovimento = 'C' THEN valor ELSE 0 END) as credito,
                        SUM(CASE WHEN tipomovimento = 'D' THEN valor ELSE 0 END) as debito
                    from movimento mov
                    inner join contacorrente cc on cc.idcontacorrente = mov.idcontacorrente
                    where mov.idcontacorrente like @IdContaCorrente";
        
        var valores = await _dbConnection.QueryFirstOrDefaultAsync(sql, new {IdContaCorrente = idContaCorrente});

        decimal totalCreditos = (decimal)(valores.credito ?? 0);
        decimal totalDebitos = (decimal)(valores.debito ?? 0);

        return totalCreditos - totalDebitos;
    }

    public async Task InserirMovimento(Movimento movimento)
    {
        var sql = @"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) 
                    VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor);";
        await _dbConnection.ExecuteAsync(sql, movimento);
    }

}
