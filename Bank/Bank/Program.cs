using Bank.Util;
using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {

        public static List<Conta> lista = new List<Conta>();


        static void Main(string[] args)
        {

            //Conta 1 de teste
            Conta conta = new Conta();
            conta.CriarConta(lista, "60642150", "123", "Antonio");

            //Conta 2 de teste
            Conta conta2 = new Conta();
            conta2.CriarConta(lista, "60642120", "1234", "Amanda",admin:"S");

            List<String> dados = new List<string>();

            dados = EntrarConta();

            if (dados.Count == 0)
            {
                Console.WriteLine("Conta não encontrada!");
                return;
            }
            if (dados[4] == "S")
            {
                MostrarPainelAdmin();
            }
            else
            {
                MostrarPainelUsuario();
            }
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            lista[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            lista[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            lista[indiceContaOrigem].Transferir(valorTransferencia, lista[indiceContaDestino]);
        }


        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Conta conta = lista[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }


        private static void MostrarPainelUsuario()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Transferir();
                        break;
                    case "2":
                        Sacar();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Transferir");
            Console.WriteLine("2- Sacar");
            Console.WriteLine("3- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterOpcaoAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void MostrarPainelAdmin()
        {
            string opcaoUsuario = ObterOpcaoAdmin();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoAdmin();
            }
        }

        private static List<String> EntrarConta()
        {
            String numCartao;
            String senha;


            Console.WriteLine("Digite o numero do cartão: ");
            numCartao = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            senha = Console.ReadLine();

            foreach (var cliente in lista)
            {
                List<String> lista2;
                lista2 = cliente.EntrarConta(numCartao, senha);
                if (lista2.Count > 0)
                {
                    return lista2;
                }
            }
            return new List<string>();
        }

        private static void CriarConta()
        {
            Conta conta = new Conta();
            String numCartao;
            String senha;
            String nome;
            TipoConta tipoConta;
            double saldo;
            double credito;
            String admin;


            numCartao = "6064" + NumeroCartao.Gerar().ToString();
            Console.WriteLine("Digite a senha: ");
            senha = Console.ReadLine();
            Console.WriteLine("Digite o nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o tipo da conta (1/2): ");
            tipoConta = (TipoConta)int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o saldo: ");
            saldo = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o credito: ");
            credito = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite se é admin ou não: ");
            admin = Console.ReadLine();


            conta.CriarConta(lista,numCartao,senha,nome,tipoConta,saldo,credito,admin);

            Console.WriteLine(numCartao);
        }

        private static string Painel()
       {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
