using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Cliente
    {
        public virtual int IdCliente { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }

        public Cliente()
        {

        }

        public Cliente(int idCliente, string nome, string email)
        {
            IdCliente = idCliente;
            Nome = nome;
            Email = email;
        }

        public override string ToString()
        {
            return $"Id Cliente: {IdCliente}, Nome: {Nome}, Email: {Email}";
        }
    }
}
