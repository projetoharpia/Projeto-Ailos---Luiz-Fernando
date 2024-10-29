using System;

namespace Questao5.Application.Commands.Responses;

public class MovimentarContaResult
{
    public Guid MovimentoId { get; set; }
    public string Mensagem { get; set; }
    public decimal ValorMovimento{ get; set; }

    public MovimentarContaResult(Guid movimentoId, string mensagem, decimal valorMovimento)
    {
        MovimentoId = movimentoId;
        Mensagem = mensagem;
        ValorMovimento = valorMovimento;
    }
}
