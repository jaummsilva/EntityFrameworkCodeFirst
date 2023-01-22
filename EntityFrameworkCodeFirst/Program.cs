using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ClienteContext())
            {
                var quantidade_clientes = context.Clientes.Count();
                context.Clientes.Add(new Cliente() { Nome = "João", Telefone = "984803109" });
                context.SaveChanges();

                context.Produtos.Add(new Produto() { Nome = "Camera 2X", Descricao = "Outra tabela" });
                context.SaveChanges();

            }
        }
    }
}
