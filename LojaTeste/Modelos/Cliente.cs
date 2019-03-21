using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaTeste.Properties
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Cliente(string nome, string cpf, string endereço, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Endereço = endereço;
            Telefone = telefone;
            Pedidos = new List<Pedido>();
        }

        public Cliente()
        {
            Pedidos = new List<Pedido>();

        }

        public void Compra(string prods)
        {
            var arr = prods.Split(',');
            var pedido = new Pedido();
            foreach (var item in arr)
            {
                pedido.AdicionarProduto(int.Parse(item));
            }

            Pedidos.Add(pedido);
        }

        public void ListarPedidos()
        {
            Console.Clear();
            Console.WriteLine("LISTA PEDIDOS");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("ID  |  NUMERO   |   DATA    |  ENDERECO    |  TELEFONE  |");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var pedido in Pedidos)
            {
                pedido.ListarProdutosComprados();
                Console.WriteLine("================================================================");
            }

        }


        public override string ToString()
        {
            return "  |       " + Nome + "     |    " + CPF + "     |    " + Endereço + "     |    " + Telefone;
        }

    }
}