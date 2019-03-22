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
            Clientes.Insert(id, C);
            Clientes.RemoveAt(id + 1);

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
            Clientes.RemoveAt(id);
        }

        #endregion

        #region Pedidos



        #endregion

        #region Produto

        public static void CadastrarProduto(Produto D)
        {
            Produtos.Add(D);
        }

        public static void EditarProduto(Produto D, int id)
        {
            Produtos.Insert(id, D);
            Produtos.RemoveAt(id + 1);

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
            Produtos.RemoveAt(id);
        }

        #endregion
    }
}