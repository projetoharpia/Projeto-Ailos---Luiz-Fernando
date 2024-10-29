using System.Globalization;

namespace Questao1;
class ContaBancaria {

    public int NumeroConta { get; }
    
    public string Titular { get; set; }
    
    public double? SaldoInicial { get; private set; }

    public ContaBancaria(int numeroConta, string titular, double? saldoInicial = 0)
    {
        NumeroConta = numeroConta;
        Titular = titular;
        SaldoInicial = saldoInicial;
    }

    public void Deposito(double valor) 
        => SaldoInicial += valor;

    public void Saque(double valor) 
        => SaldoInicial -= (valor+3.50);
    
    
}
