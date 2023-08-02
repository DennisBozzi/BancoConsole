using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoConsole.Construtores
{
    internal class Cliente
    {
        public String nome;
        public String cpf;

        public Cliente(String nome, String cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
        }

    }
}
