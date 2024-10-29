using System;

namespace Questao5.Domain.Entities;

public class ContaCorrente
{
    public Guid IdContaCorrente { get; private set; }
    public int Numero { get; private set; }
    public string Nome { get; private set; }
    public long Ativo { get; private set; }

    public ContaCorrente()
    {
        
    }

    public ContaCorrente(Guid idContaCorrente, int numero, string nome, long ativo)
    {
        IdContaCorrente = idContaCorrente;
        Numero = numero;
        Nome = nome;
        Ativo = ativo;
    }
}
