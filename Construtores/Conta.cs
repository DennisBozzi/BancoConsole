using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoConsole.Construtores
{
    internal class Conta
    {
        public int numero;
        public double saldo;
        public Cliente Cliente;

        public Conta(int numero, double saldo, Cliente Cliente)
        {
            this.numero = numero;
            this.saldo = saldo;
            this.Cliente = Cliente;
        }

    }
}
