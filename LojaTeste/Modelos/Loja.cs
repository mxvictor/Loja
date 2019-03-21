using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaTeste.Properties
{
    public class Loja
    {

        public static List<Cliente> Clientes { get; set; }
        public static List<Produto> Produtos { get; set; }

        public static void PupularLoja()
        {
            Produtos = new List<Produto>
            {
                new Produto()
                {
                    Nome = "Colar",
                    ID = "7979764",
                    Preço = 9.99,
                    Quantidade = 15

                },
                 new Produto()
                 {
                    Nome = "Pulseira",
                    ID = "4941613",
                    Preço = 5.88,
                    Quantidade = 25

                 },
                  new Produto()
                  {
                    Nome = "Missanga",
                    ID = "2825151",
                    Preço = 9.50,
                    Quantidade = 50

                  },
            };
            //Pedidos = new List<Pedido>
            //{
            //    new Pedido()
            //    {
            //        Numero = 1111,
            //        Data = "20/02/2019",


            //    },
            //     new Pedido()
            //     {
            //        Numero = 2222,
            //        Data = "20/02/2018",

            //     },
            //      new Pedido()
            //      {
            //        Numero = 3333,
            //        Data = "20/03/2019",

            //      },
            //};

            Clientes = new List<Cliente> {
                new Cliente()
                {
                    Nome = "victor",
                    CPF = "7979764",
                    Endereço = "rua 123",
                    Telefone = "7979764"

                },
                 new Cliente()
                 {
                     Nome = "rone",
                     CPF = "7979764",
                     Endereço = "rua 789",
                     Telefone = "7979764"

                 },
                  new Cliente()
                  {
                      Nome = "vinicius",
                      CPF = "7979764",
                      Endereço = "rua 453",
                      Telefone = "7979764"

                  },
            };
        }

        #region Cliente

        public static void CadastrarCliente(Cliente C)
        {
            Clientes.Add(C);
        }

        public static void EditarCliente(Cliente C, int id)
        {
            Clientes.Insert(id, C);
            Clientes.RemoveAt(id + 1);

        }

        public static void ListarClientes()
        {
            int id = 0;
            Console.Clear();
            Console.WriteLine("LISTA CLIENTES");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("ID       |     NOME        |       CPF        |       ENDERECO      |       TELEFONE     |");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (var cliente in Clientes)
            {
                Console.Write(id);
                Console.WriteLine(cliente);
                id++;
                Console.WriteLine("--------------------------------------------------------------------------------------");
            }
            id = 0;
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
            int id = 0;
            Console.Clear();
            Console.WriteLine("LISTA PRODUTOS");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("NUMERO     |     ID    |     NOME   |    PREÇO   |   QUANTIDADE   ");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var produto in Produtos)
            {
                Console.Write(id);
                Console.WriteLine(produto);
                id++;
                Console.WriteLine("------------------------------------------------------------------------");
            }
            id = 0;
        }

        public static void ExcluirProdutos(int id)
        {
            Produtos.RemoveAt(id);
        }

        #endregion
    }
}