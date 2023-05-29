using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_main.Data;
using ap1_main.Domain;

class Program{

    static void Main(){
        int i = 1;

        var db = new DataContext();
        var clienteRepository = new ClienteRepository(db);
        var contaRepository = new ContaRepository(db);
        var transacaoRepository = new TransacaoRepository(db);
        var temp = contaRepository.GetAll();
        var temp2 = clienteRepository.GetAll();
        var temp3 = transacaoRepository.GetAll();
        /*
        Console.WriteLine("Text");
        var cliente = new Cliente() {clienteId = 1, nome = "enzo", cpf = "111.111.111-11", endereco = "rua tal 123", telefone = "(51)98189-8848", email = "enzo.dragoun@rede.ulbra.br"};
        var cliente2 = new Cliente() {clienteId = 2, nome = "lucas", cpf = "222.222.222-22", endereco = "rua tal 456", telefone = "(51)12345-6789", email = "lucas@rede.ulbra.br"};
        clienteRepository.Save(cliente);
        clienteRepository.Save(cliente2);
        
        Console.WriteLine("Text");
        
        var conta = new Conta() { contaId = 1, numero = 1234567890, saldo = 250.00, clienteId = 1};
        var conta2 = new Conta() { contaId = 2, numero = 1234556789, saldo = 250.00, clienteId = 2};
        contaRepository.Save(conta);
        contaRepository.Save(conta2);
        
        var transacao = new Transacao() { contaDestino = conta, contaOrigem = conta2, valor = 100.00};
        transacaoRepository.Save(transacao);
        */
        while (i!=0)
        {
            Console.WriteLine("\n~~~~~~ MENU ~~~~~~\n");
            Console.WriteLine("1 - Adicionar Cliente -");
            Console.WriteLine("2 - Listar clientes -");
            Console.WriteLine("3 - Adicionar Conta -");
            Console.WriteLine("4 - Listar contas -"); 
            Console.WriteLine("5 - Realizar Transacao -");
            Console.WriteLine("6 - Listar transacoes -");
            Console.WriteLine("7 - Depositar em uma conta -");
            Console.WriteLine("8 - Sacar de uma conta -");
            Console.WriteLine("0 - Sair -");
            i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    Console.WriteLine("\n~~~~~~ Insira os Dados do Cliente ~~~~~~\n");
                    Console.WriteLine("Insira o nome do cliente: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Insira o CPF do cliente: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Insira o endereco do cliente: ");
                    string endereco = Console.ReadLine();
                    Console.WriteLine("Insira o telefone do cliente: ");
                    string telefone = Console.ReadLine();
                    Console.WriteLine("Insira o email do cliente: ");
                    string email = Console.ReadLine();

            

                    var newCliente = new Cliente() { nome = nome, cpf = cpf, endereco = endereco, telefone = telefone, email = email};
                    clienteRepository.Save(newCliente);
                    break;
                case 2:
                    Console.WriteLine("\n~~~~~~ Lista de Clientes Cadastrados ~~~~~~\n");
                    int f = 1;
                    var clientes = clienteRepository.GetAll();
                    foreach (var forCliente in clientes)
                    {
                         Console.WriteLine(f+$"- Nome do cliente: {forCliente.nome} CPF do cliente: {forCliente.cpf} Endereco do cliente: {forCliente.endereco} Numero do cliente: {forCliente.telefone} Email do cliente: {forCliente.email} Quantidade de contas: {(forCliente.Contas != null ? forCliente.Contas.Count: "N/A")}" );
                        f++;
                    }
                    break;
                case 3:
                    Console.WriteLine("\n~~~~~~ Insira os Dados da Conta ~~~~~~\n");
                    Console.WriteLine("Insira o numero da conta: ");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o CPF do cliente: ");
                    string cpfCliente = Console.ReadLine();
                    Console.WriteLine("Insira o saldo inicial: ");
                    double saldo = Convert.ToDouble(Console.ReadLine());
                    while (saldo < 0)
                    {
                        Console.WriteLine("Erro! O saldo inserido foi abaixo de zero!\nInsira o saldo novamente");
                        saldo = Convert.ToInt32(Console.ReadLine());
                    }
                    Cliente clienteAchado = clienteRepository.GetByCPF(cpfCliente);
                    var newConta = new Conta() {numero = numero, clienteId = clienteAchado.clienteId, saldo = saldo, cliente = clienteAchado, clienteCPF = clienteAchado.cpf};
                    contaRepository.Save(newConta);
                    break;
                case 4:
                    Console.WriteLine("\n~~~~~~ Lista de Contas Cadastradas ~~~~~~\n");
                    int g = 1;
                    var listContas = contaRepository.GetAll();
                    foreach (var contaRep in listContas)
                    {
                        Console.WriteLine($"{g} - Numero da conta: {contaRep.numero}, CPF do proprietario: {(contaRep.cliente != null ? contaRep.cliente.cpf : "N/A")} Saldo da conta: R$:{contaRep.saldo}");
                        g++;
                    }
                    int r = 1;
                    while(r!=0){
                        Console.WriteLine($"\nSelecione uma conta(0 para voltar): \n");
                        r = Convert.ToInt32(Console.ReadLine());
                        if(r!=0){
                            Conta selecConta = contaRepository.GetByNumero(r);
                            Console.WriteLine($"\n~~~~~~ Conta: {r} ~~~~~~\n");
                            Console.WriteLine($"ID da conta: {selecConta.contaId}");
                            Console.WriteLine($"Numero da conta: {selecConta.numero}");
                            Console.WriteLine($"Saldo da conta: {selecConta.saldo}");
                            Console.WriteLine($"Nome do cliente proprietario: {selecConta.cliente.nome}");
                            Console.WriteLine($"CPF do cliente proprietario: {selecConta.clienteCPF}");
                            string opc =Console.ReadLine();
                            opc = opc.ToLower();

                            switch (opc)
                            {
                                case "deletar":
                                    contaRepository.Delete(selecConta.clienteId);
                                    if (contaRepository.Delete(selecConta.clienteId) == true)
                                    {
                                        Console.WriteLine($"Conta excluida com sucesso.");
                                        
                                    }else{Console.WriteLine($"Erro ao excluir conta!");}
                                    break;
                                case "modificar":
                                    Console.WriteLine($"Trocar proprietario?(S/N)");
                                    string trcP = Console.ReadLine().ToLower();
                                    string cpfNew;
                                    if ( trcP == "s"){
                                        Console.WriteLine($"Informe o CPF do novo proprietario: ");
                                        cpfNew = Console.ReadLine();
                                        
                                    }else
                                    {
                                        break;
                                    }
                                    selecConta.clienteCPF = cpfNew;
                                    selecConta.cliente = clienteRepository.GetByCPF(cpfNew);
                                    
                                    contaRepository.Update(selecConta);
                                    
                                    break;
                                case "voltar":
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    
                break;
                case 5:
                    Console.WriteLine("\n~~~~~~ Realizar uma Transacao ~~~~~~\n");
                    Console.WriteLine($"Insira o ID da conta de origem: ");
                    int codigoOrigem = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Insira o ID da conta de destino: ");
                    int codigoDestino = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Insira o valor da transacao: ");
                    double valor = Convert.ToDouble(Console.ReadLine());

                    while (valor<0)
                    {
                        Console.WriteLine($"Erro! Valor da transferencia foi inserido incorretamente! Por favor, digite novamente: ");
                        valor = Convert.ToDouble(Console.ReadLine());
                    }

                    var newTransacao = new Transacao() { contaOrigem = contaRepository.GetByNumero(codigoOrigem), contaDestino = contaRepository.GetByNumero(codigoDestino), valor = valor};
                    newTransacao.RealizarTransacao(contaRepository, contaRepository.GetByNumero(codigoOrigem), contaRepository.GetByNumero(codigoDestino), valor);
                    transacaoRepository.Save(newTransacao);

                    break;
                case 6:
                    Console.WriteLine("\n~~~~~~ Lista de Transacoes Realizadas ~~~~~~\n");
                    int h = 1;
                    var listTrancacoes = transacaoRepository.GetAll();
                    foreach (var transRep in listTrancacoes)
                    {
                        Console.WriteLine(h+$" - Codigo da transacao: {transRep.transacaoId}, Conta de Origem: {transRep.contaOrigem.numero} Conta de Destino: {transRep.contaDestino.numero} Valor da Transacao: {transRep.valor}");
                        h++;
                    }
                    break;
                case 7:
                    Console.WriteLine("\n~~~~~~ Depositar em uma Conta ~~~~~~\n");
                    System.Console.WriteLine("Digite o numero da conta: ");
                    int idDeposito = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine("Digite o valor a depositar: ");
                    double valorDeposito = Convert.ToDouble(Console.ReadLine());
                    while (valorDeposito<0)
                    {
                        Console.WriteLine($"Erro! Valor de deposito foi inserido incorretamente! Por favor, digite novamente: ");
                        valorDeposito = Convert.ToInt32(Console.ReadLine());
                    }

                    var contaDeposito = contaRepository.GetById(idDeposito);
                    contaDeposito.Depositar(contaRepository, contaDeposito, valorDeposito);

                    break;
                case 8:
                    Console.WriteLine("\n~~~~~~ Sacar de uma Conta ~~~~~~\n");
                    System.Console.WriteLine("Digite o numero da conta: ");
                    int idSaque = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine("Digite o valor a sacar: ");
                    double valorSaque = Convert.ToDouble(Console.ReadLine());
                    while (valorSaque<0)
                    {
                        Console.WriteLine($"Erro! Valor de saque foi inserido incorretamente! Por favor, digite novamente: ");
                        valorSaque = Convert.ToInt32(Console.ReadLine());
                    }
                    var contaSaque = contaRepository.GetById(idSaque);
                    contaSaque.Sacar(contaRepository, contaSaque, valorSaque);

                    break;
                default:
                    break;
            }
            
        }
    }
}