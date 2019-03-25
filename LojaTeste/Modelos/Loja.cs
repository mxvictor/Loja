using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LojaTeste.Modelos
{
    public class Loja
    {

        public static List<Cliente> Clientes { get; set; }
        public static List<Produto> Produtos { get; set; }


        #region Cliente

        public static void CadastrarCliente(Cliente C)
        {
            Banco banco = new Banco();

            banco.sql = $@"INSERT INTO public.cliente (clie_nome, clie_cpf, clie_endereco, clie_telefone) 
                            VALUES (@nome, @cpf, @endereco, @telefone)";

            banco.addParametros("nome", C.Nome);
            banco.addParametros("cpf", C.CPF);
            banco.addParametros("endereco", C.Endereço);
            banco.addParametros("telefone", C.Telefone);

            banco.ExecutarReader();
        }

        public static void EditarCliente(Cliente C, int id)
        {
            Banco banco = new Banco();

            banco.sql = $@"UPDATE cliente
                           SET clie_nome = @nome,
                               clie_telefone = @telefone  ,
                               clie_endereco = @endereco
                           WHERE
                               clie_id = @id;";
            banco.addParametros("id", id);
            banco.addParametros("nome", C.Nome);
            banco.addParametros("telefone", C.Telefone);
            banco.addParametros("endereco", C.Endereço);
            banco.ExecutarReader();


        }

        public static void ListarClientes()
        {
            Banco banco = new Banco();

            banco.sql = $@"SELECT clie_id,clie_nome,clie_cpf,clie_endereco,clie_telefone
                            FROM cliente
                            ORDER BY clie_nome ASC";

            var ds = banco.ExecutarReader();

            while (ds.Read())
            {
                for(int i = 0; i < ds.FieldCount; i++)
                {
                    Console.Write("{0}\t",ds[i]);
                }
                Console.WriteLine("");
            }
        }

        public static void ExcluirClientes(int id)
        {
            Banco banco = new Banco();

            banco.sql = $@"DELETE FROM public.cliente 
                           WHERE clie_id = @id";

            banco.addParametros("id", id);
            banco.ExecutarReader();
        }

        #endregion

        #region Pedidos

        public static int CadastrarPedido(int id)
        {
            Banco banco = new Banco();

            banco.sql = $@"INSERT INTO public.pedido (pedi_clie_id) 
                            VALUES (@id )returning pedi_numero";

            banco.addParametros("id", id);

            var num_pedi = banco.ExecutarReader();
            num_pedi.Read();
            return Convert.ToInt32(num_pedi[0]);
        }

        public static void ProdutosPedido(int id, int qnt, int pedi_id)
        {
            Banco banco = new Banco();

            banco.sql = $@"INSERT INTO public.pedido_item (pedi_item_prod_id,pedi_pedi_item_numero,pedi_quantidade) 
                            VALUES (@id,@numero,@quantidade)";

            banco.addParametros("id", id);
            banco.addParametros("numero", pedi_id);
            banco.addParametros("quantidade", qnt);


            banco.ExecutarReader();
        }

        #endregion

        #region Produto

        public static void CadastrarProduto(Produto D)
        {
            Banco banco = new Banco();

            banco.sql = $@"INSERT INTO public.produto (prod_nome, prod_preco, prod_quantidade) 
                            VALUES (@nome, @preco, @quantidade)";
            
            banco.addParametros("nome",D.Nome);
            banco.addParametros("preco", D.Preco);
            banco.addParametros("quantidade", D.Quantidade);

            banco.ExecutarReader();
        }

        public static void EditarProduto(Produto D, int id)
        {
            //Produtos.Insert(id, D);
            //Produtos.RemoveAt(id + 1);
            Banco banco = new Banco();

            banco.sql = $@"UPDATE produto
                           SET prod_nome = @nome,
                               prod_preco = @preco  ,
                               prod_quantidade = @quantidade
                           WHERE
                               prod_id = @id;";

            banco.addParametros("id", id);
            banco.addParametros("nome", D.Nome);
            banco.addParametros("preco", D.Preco);
            banco.addParametros("quantidade", D.Quantidade);
            banco.ExecutarReader();


        }

        public static void ListarProdutos()
        {
            Banco banco = new Banco();

            banco.sql = $@"SELECT  prod_id,prod_nome,prod_preco,prod_quantidade
                            FROM produto
                            ORDER BY prod_nome ASC";

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

        public static void ExcluirProdutos(int id)
        {
            Banco banco = new Banco();

            banco.sql = $@"DELETE FROM public.produto 
                           WHERE prod_id = @id";

            banco.addParametros("id", id);
            banco.ExecutarReader();
        }

        #endregion
    }
}