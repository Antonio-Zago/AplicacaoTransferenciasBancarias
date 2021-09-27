using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Conta
    {
        private String nome { get; set; }
        private TipoConta tipoConta { get; set; }

        private double saldo { get; set; }

        private double credito { get; set; }

        private String numCartao {get; set;}

        private String senha { get; set; }
        private String admin { get; set; }


        public Conta() { }

        //Como os atributos estão como private é importante criar esse construtor para atribuir inicialmente os valores
        public Conta(TipoConta tipoConta, double saldo, double credito, String nome, String numCartao, String admin) 
        {
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
            this.numCartao = numCartao;
            this.admin = admin;
        }


        public bool Sacar(double valorSaque)
        {
            if (valorSaque > this.credito + this.saldo)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }


            this.saldo -= valorSaque;

            if(this.saldo < 0)
            {
                this.credito = this.credito - (this.saldo * -1);
                this.saldo = 0;
            }

            Console.WriteLine("{0},\n Saldo atual: {1},\n Crédito atual: {2}", this.nome, this.saldo, this.credito);

            return true;

        }

        public void Depositar(double valor)
        {
            this.saldo += valor;

            Console.WriteLine("{0},\n Saldo atual: {1},\n Crédito atual: {2}", this.nome, this.saldo, this.credito);
        }

        public void Transferir(double valor, Conta destino)
        {
            if (this.Sacar(valor))
            {
                destino.Depositar(valor);   
            }
        }

        public void status()
        {
            String retorno = "Nome: " + this.nome + 
                " | Tipo da conta: " + this.tipoConta+
                " | Saldo atual: " + this.saldo+ 
                " | Credito atual: " + this.credito;
            Console.WriteLine(retorno);
        }

        public List<String> EntrarConta(string numCartao, string senha)
        {
            String senhaCripto = MD5Hash.CalculaHash(senha);
            List<String> lista = new List<string>();

            if (this.numCartao == numCartao && this.senha == senhaCripto )
            {
                lista.Add(this.nome);
                lista.Add(this.saldo.ToString());
                lista.Add(this.tipoConta.ToString());
                lista.Add(this.credito.ToString());
                lista.Add(this.admin.ToString());
                return lista;
            }
            else
            {
                return new List<string>();
            }
        }

        public bool VerificaNumCartao(Conta conta, int numCartao)
        {
            if (conta.numCartao == numCartao.ToString())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CriarConta(List<Conta> lista, string numCartao = "", string senha = "", string nome = "", TipoConta tipoConta = TipoConta.PessoaFisica, double saldo = 200, double credito = 400, string admin = "N")
        {
            this.numCartao = numCartao;
            this.senha = MD5Hash.CalculaHash(senha);
            this.nome = nome;
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.admin = admin;

            lista.Add(this);
        }
    }
}
