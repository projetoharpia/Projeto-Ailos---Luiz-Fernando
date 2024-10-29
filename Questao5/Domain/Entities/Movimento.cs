using System;

namespace Questao5.Domain.Entities;

public class Movimento
{
    public Guid IdMovimento { get; private set; } 
    public Guid IdContaCorrente { get; private set; }
    public DateTime DataMovimento { get; private set; }
    public char TipoMovimento { get; private set; }
    public decimal Valor { get; private set; }

 
    public Movimento(Guid idMovimento, Guid idContaCorrente, DateTime dataMovimento, char tipoMovimento, decimal valor)
    {
        IdMovimento = idMovimento;
        IdContaCorrente = idContaCorrente;
        DataMovimento = dataMovimento;
        TipoMovimento = tipoMovimento;
        Valor = valor;
    }
}
