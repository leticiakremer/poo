namespace TrabalhoPooBanco.Entities;
//Aqui temos um exemplo de uma classe abstrata, pois ela não pode ser instanciada, 
//apenas ser base para outra classe como veremos ela nas Classe Transferencia; Saque e Deposito.
public abstract class Transacao
{
    public decimal Valor { get; protected set; } // aqui nós temos a representaçao de uma propriedade com dois parametros, get retorna o valor da prorpiedade e o set é para se definir o valor da propriedade neste caso como esta protegida.

    public Transacao(decimal valor)
    {
        Valor = valor;
    }

    public abstract Resultado Executar();
}