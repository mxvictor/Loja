using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaTeste.Modelos
{
    public class Produto
    {
        //public string ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, double preço, int quantidade)
        {
            Nome = nome;
            Preco = preço;
            Quantidade = quantidade;
        }

        public Produto()
        {

        }

        //public override string ToString()
        //{
        //    return "           |  " + ID + "  |   " + Nome + "     |    " + Preço + "     |    " + Quantidade + "     |    ";
        //}
    }
}