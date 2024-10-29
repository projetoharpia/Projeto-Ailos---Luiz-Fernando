using System.Data;
using Dapper;
using Questao5.Application.Repositories;

namespace Questao5.Infrastructure.Database.Repositories;

public class IdempotenciaRepository: IIdempotenciaRepository
{
    private readonly IDbConnection _dbConnection; 
    
    public IdempotenciaRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<bool> ExisteIdempotencia(string chaveIdempotencia)
    {
        var sql = "SELECT COUNT(*) FROM Idempotencia where chave_idempotencia = @ChaveIdempotencia";
        var count = await _dbConnection.ExecuteScalarAsync<int>(sql, new { ChaveIdempotencia = chaveIdempotencia});
        return count > 0;
    }

    public async Task RegistrarIdempotencia(string chaveIdempotencia, string requisicao, string resultado)
    {
        var sql = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) VALUES (@ChaveIdempotencia, @Requisicao, @Resultado)";
        await _dbConnection.ExecuteAsync(sql, new { ChaveIdempotencia = chaveIdempotencia, Requisicao = requisicao, Resultado = resultado });
    }
}
