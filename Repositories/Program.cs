using static System.Console;
using TrabalhoPooBanco.Entities;
using TrabalhoPooBanco.Repositories;



do
{
    WriteLine("--- Escolha a operação que deseja realizar");
    WriteLine("------- 1 - Criar uma conta");
    WriteLine("------- 2 - Listar clientes");
    WriteLine("------- 3 - Realizar uma transferência");
    WriteLine("------- 4 - Realizar um saque");
    WriteLine("------- 5 - Realizar um depósito");
    WriteLine("------- 6 - Sair");

    var input = ReadLine();
    if (!int.TryParse(input, out var escolha))
    {
        WriteLine("Você não informou uma opção correta!");
        continue;
    }

    if (escolha == 1)
    {
        //Criar conta
        WriteLine("Certo, vamos criar a sua conta!!");
        WriteLine("Informe o seu nome:");
        var nome = ReadLine();

        WriteLine("Informe o seus cpf:");
        var cpf = ReadLine();

        WriteLine("Informe o seu sexo:");
        WriteLine("-- 1 para masculino");
        WriteLine("-- 2 para feminino");
        var sexoInput = ReadLine();

        var conta = new ContaCorrente(Random.Shared.NextInt64(2000).ToString(), 0);
        var cliente = new Cliente(nome, cpf, Enum.Parse<ESexo>(sexoInput), conta);

// camada de encapsulamento controla o banco
        var repository = new ClienteRepository();
        repository.Salvar(cliente);

        cliente.MostrarDados();
    }
    else if (escolha == 2)
    {
        var repository = new ClienteRepository();
        var clientes = repository.Listar();
        foreach (var cliente in clientes)
        {
            cliente.MostrarDados();
            WriteLine();
        }
    }
    else if (escolha == 3)
    {
        WriteLine("Informe o número da conta de origem:");
    var numeroContaOrigem = ReadLine();
    var repository = new ClienteRepository();
    var clienteOrigem = repository.ObterClientePeloNumeroConta(numeroContaOrigem);
    if (clienteOrigem == null)
    {
        WriteLine("Conta de origem não existente!");
        continue;
    }

    WriteLine("Informe o número da conta de destino:");
    var numeroContaDestino = ReadLine();
    var clienteDestino = repository.ObterClientePeloNumeroConta(numeroContaDestino);
    if (clienteDestino == null)
    {
        WriteLine("Conta de destino não existente!");
        continue;
        }

    WriteLine("Informe o valor que deseja transferir:");
    var valorInput = ReadLine();
    //Validar se realmente é um decimal
    var valor = decimal.Parse(valorInput);

    var transferencia = new Transferencia(clienteOrigem, clienteDestino, valor);
    var resultado = transferencia.Executar();

    var transacaoRepository = new TransacaoRepository();
    transacaoRepository.Salvar(transferencia);

    WriteLine(resultado.Mensagem);

    }
    else if (escolha == 4)
    {
        WriteLine("Informe o número da conta que deseja fazer saque:");
var numeroConta = ReadLine();

var repository = new ClienteRepository();
var cliente = repository.ObterClientePeloNumeroConta(numeroConta);
if (cliente == null)
{
    WriteLine("Conta não existente!");
    continue;
}

WriteLine("Informe o valor que deseja sacar da conta:");
var valorInput = ReadLine();
//Validar se realmente é um decimal
var valor = decimal.Parse(valorInput);

var saque = new Saque(cliente, valor);
var resultado = saque.Executar();

var transacaoRepository = new TransacaoRepository();
transacaoRepository.Salvar(saque);

WriteLine(resultado.Mensagem);
    }
    else if (escolha == 5)
    {

        WriteLine("Informe o número da conta que deseja fazer depósito:");
        var numeroConta = ReadLine();

        var repository = new ClienteRepository();
        var cliente = repository.ObterClientePeloNumeroConta(numeroConta);
        if (cliente == null)
        {
            WriteLine("Conta não existente!");
            continue;
        }

        WriteLine("Informe o valor que deseja depositar na conta:");
        var valorInput = ReadLine();
        //Validar se realmente é um decimal
        var valor = decimal.Parse(valorInput);
        var deposito = new Deposito(cliente, valor);
        var resultado = deposito.Executar();

        var transacaoRepository = new TransacaoRepository();
        transacaoRepository.Salvar(deposito);

        WriteLine(resultado.Mensagem);
    }
    else if (escolha == 6)
    {
        Console.WriteLine("Obrigado por utilizar nosso sistema! Até mais!");
        return;
    }
    else
    {
        WriteLine("Você não informou uma opção correta!");
        continue;
    }
    

} while (true);