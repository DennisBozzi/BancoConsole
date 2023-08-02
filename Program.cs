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
                    Console.WriteLine("3");
                    break;
                case 4:
                    Console.WriteLine("4");
                    break;
                case 5:
                    Console.WriteLine("5");
                    break;
                case 6:
                    Console.WriteLine("6");
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
            Console.Write("Digite o Nome:");
            String nome = Console.ReadLine();

            Console.Write("Digite o CPF:");
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
                Console.Write("\nDigite o número da conta:");
                numero = int.Parse(Console.ReadLine());
                Console.Write("Digite o saldo da conta:");
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
        void depositar(int numero, String cpf)
        {

            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua o deposito
            {

            }
            else //Caso a conta seja null
            {
                Console.WriteLine("A Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }
        }

        //Saca o dinheiro da conta
        void sacar(int numero, String cpf)
        {
            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua o saque
            {

            }
            else //Caso a conta seja null
            {
                Console.WriteLine("A Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }
        }//Saca o dinheiro da conta

        void consultar(String cpf)
        {
            Conta conta = testaCpfRetornaConta(cpf);

            if (conta != null) //Caso a conta seja diferente de null, continua o saque
            {

            }
            else //Caso a conta seja null
            {
                Console.WriteLine("A Conta não foi encontrada. Aperte enter para continuar...");
                Console.ReadKey();
            }
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
