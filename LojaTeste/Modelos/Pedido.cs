using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaTeste.Properties
{
    public class Pedido
    {
        public int Numero { get; set; }
        public string Data { get; set; }
        public List<Produto> ProdutosComprados { get; set; }

        public Pedido(int numero, string data)
        {
            Numero = numero;
            Data = data;
            ProdutosComprados = new List<Produto>();
        }

        public Pedido()
        {
            ProdutosComprados = new List<Produto>();
        }

        public void AdicionarProduto(int num)
        {
            var Produto = Loja.Produtos[num];
            ProdutosComprados.Add(Produto);
        }

        public void ListarProdutosComprados()
        {

            int id = 0;

            foreach (var produto in ProdutosComprados)
            {
                Console.Write(id);
                Console.WriteLine(produto);
                id++;
                Console.WriteLine("-----------------------------------------------------");
            }
            id = 0;
        }

        public override string ToString()
        {
            return "           |  " + Numero + "  |   " + Data + "     |    ";// + . + "     |    " + Quantidade + "     |    ";
        }

    }
}