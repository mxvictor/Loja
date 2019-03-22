using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LojaTeste.Modelos
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

            //int id = 0;

            //foreach (var produto in ProdutosComprados)
            //{
            //    Console.Write(id);
            //    Console.WriteLine(produto);
            //    id++;
            //    Console.WriteLine("-----------------------------------------------------");
            //}
            //id = 0;
            Banco banco = new Banco();

            banco.sql = "SELECT clie_id,clie_nome,clie_cpf,clie_endereco,clie_telefone\nFROM cliente\nORDER BY clie_nome ASC";

            var ds = banco.ExecutarReader();

            while (ds.Read())
            {
                for (int i = 0; i < ds.FieldCount; i++)
                {
                    Console.Write("{0}\t", ds[i]);
                }
                Console.WriteLine("");
            }

        }

        public override string ToString()
        {
            return "           |  " + Numero + "  |   " + Data + "     |    ";// + . + "     |    " + Quantidade + "     |    ";
        }

    }
}