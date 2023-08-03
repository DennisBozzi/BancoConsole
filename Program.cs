using BancoConsole.Construtores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoConsole
{

    internal class Program
    {
        //Lista de Clientes cadastrados
        static List<Cliente> clientes = new List<Cliente>();

        //Lista de Contas cadastradas
        static List<Conta> contas = new List<Conta>();

        static void Main(string[] args)
        {

            //Função que printa as opções e recolhe a opção do usuário
            opcoes();

        }

        static void opcoes()
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao Banco Europa. O que gostaria de fazer?");

            Console.WriteLine("\n1 - Novo Cliente");
            Console.WriteLine("2 - Nova Conta");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Consultar");
            Console.WriteLine("6 - Transferir");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha:");

            //Função que recolhe a opção do usuário
            escolha(int.Parse(Console.ReadLine()));
        }

        static void escolha(int escolha)
        {
            switch (escolha)
            {
                case 1: //Novo Cliente
                    novoCliente();
                    break;
                case 2: //Nova Conta
                    novaConta();
                    break;
                case 3:
                    depositar();
                    break;
                case 4:
                    sacar();
                    break;
                case 5:
                    consultar();
                    break;
                case 6:
                    transferir();
                    break;
                case 0:
                    break;
                default:
                    opcoes();
                    break;
            }
        }

        /* ------------------------------ Novo Cliente - Nova Conta ------------------------------ */

        //Cria novo Cliente e adiciona na lista clientes
        static void novoCliente()
        {
            Console.Clear();
            Console.WriteLine(" - Novo Cliente - ");
            Console.Write("Digite o Nome: ");
            String nome = Console.ReadLine();

            Console.Write("Digite o CPF: ");
            String cpf = Console.ReadLine();

            if (!testaCpf(cpf))
            {
                Cliente novoCliente = new Cliente(nome, cpf);

                clientes.Add(novoCliente);

                Console.WriteLine("\nNovo cliente cadastrado. Aperte enter para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("O CPF já está cadastrado. Aperte enter para continuar...");
                Console.ReadKey();
            }

            opcoes();
        }

        //Cria uma nova Conta e adiciona na lista contas
        static void novaConta()
        {
            Console.Clear();
            Console.WriteLine(" - Nova Conta - ");
            Console.Write("\nDigite o CPF do Cliente que abrirá a conta: ");

            String cpf = Console.ReadLine();
            Cliente cliente = testaCpfRetornaCliente(cpf);
            int numero;
            int saldo;

            if (cliente != null) //Caso o cliente seja diferente de null ele continua o cadastro
            {
                Console.Write("\nDigite o número da conta: ");
                numero = int.Parse(Console.ReadLine());
                Console.Write("Digite o saldo da conta: ");
                saldo = int.Parse(Console.ReadLine());

                Conta novaConta = new Conta(numero, saldo, cliente);

                contas.Add(novaConta);

                Console.WriteLine("\nNova conta cadastrada. Aperte enter para continuar...");
                Console.ReadKey();
            }
            else //Caso o cliente seja null
            {
                Console.WriteLine("O CPF não foi encontrado. Aperte enter para continuar...");
                Console.ReadKey();
            }

            opcoes();

        }

        /* ---------------------- Depositar - Sacar - Consultar - Transferir --------------------- */

        //Deposita o dinheiro na conta
        static void depositar()
        {
            Console.Clear();

            Console.WriteLine("Qual o CPF do titular da conta que gostaria de depositar?");
            String cpf = Console.ReadLine();

            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua o deposito
            {
                Console.WriteLine("Qual o valor que gostaria de depositar?");
                double valor = double.Parse(Console.ReadLine());

                conta.saldo = conta.saldo + valor;

                Console.WriteLine("\nO novo saldo da conta é de R$: " + conta.saldo + "\nAperte enter para continuar...");
                Console.ReadKey();
            }
            else //Caso a conta seja null
            {
                Console.WriteLine("A Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }
            opcoes();
        }

        //Saca o dinheiro da conta
        static void sacar()
        {
            Console.Clear();

            Console.WriteLine("Qual o CPF do titular da conta que gostaria de sacar?");
            String cpf = Console.ReadLine();

            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua o saque
            {
                Console.WriteLine("\nQual o valor que gostaria de sacar? A conta possui o valor de R$" + conta.saldo);
                double valor = double.Parse(Console.ReadLine());
                if (conta.saldo >= valor)
                {
                    conta.saldo = conta.saldo - valor;
                    Console.WriteLine("O valor foi sacado. A conta agora possui o valor de R$" + conta.saldo + "\nAperte enter para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nA conta não possui esse valor para ser sacado." + "\nAperte enter para continuar...");
                    Console.ReadKey();
                }
            }
            else //Caso a conta seja null
            {
                Console.WriteLine("A Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }

            opcoes();
        }

        //Consulta a conta
        static void consultar()
        {
            Console.Clear();

            Console.WriteLine("Qual o CPF do titular da conta que gostaria de consultar?");
            String cpf = Console.ReadLine();

            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua a consulta
            {

                Console.Clear();

                Console.WriteLine("Dados da conta");
                Console.WriteLine("Número: " + conta.numero);
                Console.WriteLine("Saldo: R$" + conta.saldo);
                Console.WriteLine("Cliente:");
                Console.WriteLine(conta.Cliente.toString());

                Console.WriteLine("\nAperte enter para continuar...");
                Console.ReadKey();

            }
            else //Caso a conta seja null
            {
                Console.WriteLine("\nA Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }

            opcoes();
        }

        //Transfere
        static void transferir()
        {
            Console.Clear();
            Console.Write("De qual conta gostaria de transferir?\nInsira o CPF do titular da conta:");
            String cpf = Console.ReadLine();

            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua o saque
            {
                Console.Clear();
                Console.Write("Valor na conta: R$" + conta.saldo + "\nDigite o valor que gostaria de transferir:");
                double valor = double.Parse(Console.ReadLine());

                if (conta.saldo >= valor) //Caso o valor da conta que irá transferir seja menor que seu saldo
                {
                    Console.Write("\n\nPara qual conta gostaria de transferir?\nDigite o CPF do titular da conta:");
                    String cpf2 = Console.ReadLine();
                    Conta conta2 = testaCpfRetornaConta(cpf2);

                    if (conta2 != null) //Caso a conta que receberá não seja nula
                    {
                        conta.saldo = conta.saldo - valor;
                        conta2.saldo = conta2.saldo + valor;

                        Console.WriteLine("\nTransferência realizada!");
                        Console.WriteLine("Saldo conta que transferiu: R$" + conta.saldo);
                        Console.WriteLine("Saldo conta que recebeu: R$" + conta2.saldo);
                        Console.WriteLine("\nAperte enter para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nA Conta não foi encontrada. Aperte enter para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nSaldo insuficiente na conta. Aperte enter para continuar...");
                    Console.ReadKey();
                }
            }
            else //Caso a conta seja null
            {
                Console.WriteLine("\nA Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }

            opcoes();
        }

        /* -------------------------- Testes de CPF - Cliente - Contas --------------------------- */

        //Testa se o CPF já está cadastrado e retorna o cliente
        static Cliente testaCpfRetornaCliente(String cpf)
        {

            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente clienteTeste = clientes[i];

                String cpfTeste = clienteTeste.cpf;

                if (cpf == cpfTeste)
                {
                    return clienteTeste;
                }

            }

            return null;
        }

        //Testa se o CPF já está cadastrado
        static bool testaCpf(String cpf)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente clienteTeste = clientes[i];

                String cpfTeste = clienteTeste.cpf;

                if (cpf == cpfTeste)
                {
                    return true;
                }

            }

            return false;
        }

        //Testa se o CPF já está cadastrado e retorna o cliente
        static Conta testaCpfRetornaConta(String cpf)
        {

            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente clienteTeste = clientes[i];

                if (cpf == clienteTeste.cpf)
                {

                    for (int j = 0; j < contas.Count; j++)
                    {
                        Conta contaTeste = contas[j];

                        if (contaTeste.Cliente == clienteTeste)
                        {
                            return contaTeste;
                        }


                    }

                }

            }

            return null;
        }
    }
}
