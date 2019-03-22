using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using LojaTeste.Modelos;

namespace LojaTeste
{
    class Program
    {


        static void Main(string[] args)
        {

            MenuLoja();
            int op = int.Parse(Console.ReadLine());
            //Loja.PupularLoja();
            Cliente Cliente = new Cliente();


            while (op != 0)
            {
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        var C = MenuCadastrarCliente();
                        Loja.CadastrarCliente(C);
                        op = 5;
                        break;

                    case 2:
                        Console.Clear();
                        var D = MenuCadastrarProduto();
                        Loja.CadastrarProduto(D);
                        op = 5;
                        break;

                    case 3:
                        Console.Clear();
                        Loja.ListarClientes();
                        Console.WriteLine("ID DO CLIENTE:");
                        int index = int.Parse(Console.ReadLine());
                        Console.Clear();
                        MenuCliente();
                        int op4 = int.Parse(Console.ReadLine());
                        switch (op4)
                        {
                            case 1:
                                C = MenuCadastrarCliente();
                                Loja.EditarCliente(C, index);
                                op4 = 1;
                                break;

                            case 2:
                                Loja.ListarClientes();
                                Loja.ExcluirClientes(index);
                                break;

                            case 3:
                                Loja.ListarProdutos();
                                Console.WriteLine("SELECIONE O NUMERO DO PRODUTO COMPRADO: ");
                                string num = Console.ReadLine();
                                Loja.Clientes[index].Compra(num);


                                break;

                            case 4:
                                //Loja.Clientes[index].ListarPedidos();
                                Cliente.ListarPedidos(index);
                                Console.WriteLine("APERTE 5 PARA VOLTAR:");
                                op4 = int.Parse(Console.ReadLine());
                                break;

                            case 5:

                                break;
                            case 0:

                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Loja.ListarProdutos();
                        Console.WriteLine("ID DO PRODUTO:");
                        index = int.Parse(Console.ReadLine());
                        Console.Clear();
                        MenuProdutos();
                        int op2 = int.Parse(Console.ReadLine());
                        switch (op2)
                        {
                            case 1:
                                D = MenuCadastrarProduto();
                                Loja.EditarProduto(D, index);
                                op4 = 1;
                                break;

                            case 2:
                                Loja.ListarProdutos();
                                Loja.ExcluirProdutos(index);
                                break;
                        }
                        break;

                    case 5:
                        Console.Clear();
                        MenuLoja();
                        op = int.Parse(Console.ReadLine());
                        break;
                }
            }

        }

        public static Cliente MenuCadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO");
            Console.Write("Nome: ");
            string Nome = Console.ReadLine();
            Console.Write("CPF: ");
            string CPF = Console.ReadLine();
            Console.Write("Endereço: ");
            string Endereço = Console.ReadLine();
            Console.Write("Telefone: ");
            string Telefone = Console.ReadLine();
            return new Cliente(Nome, CPF, Endereço, Telefone);
        }

        public static Cliente MenuEditarCliente()
        {
            Console.Clear();
            Console.WriteLine("ALTERAÇÃO CLIENTE");
            Console.Write("Nome: ");
            string Nome = Console.ReadLine();
            Console.Write("CPF: ");
            string CPF = Console.ReadLine();
            Console.Write("Endereço: ");
            string Endereço = Console.ReadLine();
            Console.Write("Telefone: ");
            string Telefone = Console.ReadLine();
            return new Cliente(Nome, CPF, Endereço, Telefone);

        }

        public static void MenuLojaCliente()
        {
            Console.WriteLine(" --------------------------- ");
            Console.WriteLine("| Escolha a opção desejada: |");
            Console.WriteLine("| 0- Sair                   |");
            Console.WriteLine("| 2- Editar                 |");
            Console.WriteLine("| 4- Excluir                |");
            Console.WriteLine(" --------------------------- ");
        }

        public static void MenuLoja()
        {
            Console.WriteLine(" --------------------------- ");
            Console.WriteLine("| Escolha a opção desejada: |");
            Console.WriteLine("| 0- Sair                   |");
            Console.WriteLine("| 1- Cadastrar Cliente      |");
            Console.WriteLine("| 2- Cadastrar Produto      |");
            Console.WriteLine("| 3- Selecionar Cliente     |");
            Console.WriteLine("| 4- Selecionar Produto     |");
            Console.WriteLine(" --------------------------- ");
        }

        public static void MenuCliente()
        {
            Console.WriteLine(" --------------------------- ");
            Console.WriteLine("| Escolha a opção desejada: |");
            Console.WriteLine("| 0- Sair                   |");
            Console.WriteLine("| 1- Editar                 |");
            Console.WriteLine("| 2- Remover                |");
            Console.WriteLine("| 3- Comprar                |");
            Console.WriteLine("| 4- Listar Pedidos         |");
            Console.WriteLine(" --------------------------- ");
        }

        public static void MenuProdutos()
        {
            Console.WriteLine(" --------------------------- ");
            Console.WriteLine("| Escolha a opção desejada: |");
            Console.WriteLine("| 0- Sair                   |");
            Console.WriteLine("| 1- Editar                 |");
            Console.WriteLine("| 2- Remover                |");
            Console.WriteLine(" --------------------------- ");
        }

        public static void MenuLojaProduto()
        {
            Console.WriteLine(" --------------------------- ");
            Console.WriteLine("| Escolha a opção desejada: |");
            Console.WriteLine("| 0- Sair                   |");
            Console.WriteLine("| 2- Editar                 |");
            Console.WriteLine("| 4- Excluir                |");
            Console.WriteLine(" --------------------------- ");

        }
        public static Produto MenuCadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO");
            Console.Write("ID: ");
            string Id = Console.ReadLine();
            Console.Write("NOME: ");
            string Nome = Console.ReadLine();
            Console.Write("PREÇO: ");
            double Preço = double.Parse(Console.ReadLine());
            Console.Write("QUANTIDADE: ");
            int Quantidade = int.Parse(Console.ReadLine());
            return new Produto(Id, Nome, Preço, Quantidade);
        }

        public static Produto MenuEditarProduto()
        {
            Console.Clear();
            Console.WriteLine("ALTERAÇÃO PRODUTO");
            Console.Write("ID: ");
            string Id = Console.ReadLine();
            Console.Write("NOME: ");
            string Nome = Console.ReadLine();
            Console.Write("PREÇO: ");
            double Preço = double.Parse(Console.ReadLine());
            Console.Write("QUANTIDADE: ");
            int Quantidade = int.Parse(Console.ReadLine());
            return new Produto(Id, Nome, Preço, Quantidade);

        }
    }
}