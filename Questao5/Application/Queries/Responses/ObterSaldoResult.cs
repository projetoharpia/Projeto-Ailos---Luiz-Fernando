using System;

namespace Questao5.Application.Queries.Responses;

public class ObterSaldoResult
{
    public decimal Saldo { get; set; }
    public string? Nome { get; set; }
    public string Mensagem { get; set; }

    public ObterSaldoResult(decimal saldo, string? nome, string mensagem)
    {
        Saldo = saldo;
        Nome = nome;
        Mensagem = mensagem;
    }
}
