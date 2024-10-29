using System;
using System.Globalization;

namespace Questao1;

class Program
{
    enum OperacaoBancaria
    {
        Deposito,
        Saque
    };
    
    static void Main(string[] args) {
        ContaBancaria conta = CriarConta();
        ExibirDadosConta(conta);

        EfetuarOperacaoBancaria(conta, OperacaoBancaria.Deposito);
        EfetuarOperacaoBancaria(conta, OperacaoBancaria.Saque);
    }
    
    static ContaBancaria CriarConta()
    {
        Console.Write("Entre o número da conta: ");
        int numero;
        while(!int.TryParse(Console.ReadLine(), out numero))
            Console.WriteLine("Informe um numero válido para a conta:");
        
        Console.Write("Entre o titular da conta: ");
        string titular = Console.ReadLine();

        Console.Write("Haverá depósito inicial (s/n)? ");
        char resp = Char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (resp == 'S') {
            double depositoInicial = SolicitarValor("Entre o valor de depósito inicial: ");
            return new ContaBancaria(numero, titular, depositoInicial);
        } else {
            return new ContaBancaria(numero, titular);
        }
    }
    
    static double SolicitarValor(string mensagem) 
    {
        Console.Write(mensagem);
        double valor;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.InvariantCulture, out valor)) {
            Console.Write("Valor inválido. " + mensagem);
        }
        return valor;
    }
    
    static void ExibirDadosConta(ContaBancaria conta, string mensagem = "Dados da conta:") 
    {
        Console.WriteLine();
        Console.WriteLine(mensagem);
        Console.WriteLine($"Conta {conta.NumeroConta}, Titular: {conta.Titular}, Saldo: ${conta.SaldoInicial}");
    }
    
    static void EfetuarOperacaoBancaria(ContaBancaria conta, OperacaoBancaria operacao)
    {
        Console.WriteLine();
        Double valor;
        switch (operacao)
        {
            case OperacaoBancaria.Deposito:
                valor = SolicitarValor($"Entre um valor para depósito:");
                conta.Deposito(valor);
                break;
            case OperacaoBancaria.Saque:
                valor = SolicitarValor($"Entre um valor para saque:");
                conta.Saque(valor);
                break;
        }
        ExibirDadosConta(conta, "Dados da conta atualizados:");
    }
}

