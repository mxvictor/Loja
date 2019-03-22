using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LojaTeste.Modelos
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

        public void ListarPedidos(int clientID)
        {
            Banco banco = new Banco();

            banco.sql = $@"SELECT pedi_numero,clie_nome, SUM(prod_preco * pedi_quantidade) AS total
                            FROM pedido
                            INNER JOIN cliente c on pedido.pedi_clie_id = c.clie_id
                            INNER JOIN pedido_item pi on pedido.pedi_numero = pi.pedi_pedi_item_numero
                            INNER JOIN produto p on pi.pedi_item_prod_id = p.prod_id
                            WHERE clie_id = @p
                            GROUP BY pedi_numero,clie_nome";

            banco.addParametros("p", clientID);

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
            return "  |       " + Nome + "     |    " + CPF + "     |    " + Endereço + "     |    " + Telefone;
        }

    }
}