namespace TrabalhoPooBanco.Entities;
//Herança permite criar uma nova classe a partir de uma classe existent, como aqui cliente herda da Classe ContaCorrente
public class ContaCorrente : Conta
{
    public ContaCorrente(string numero, decimal saldo) : base(numero, saldo)
    {
    }
}