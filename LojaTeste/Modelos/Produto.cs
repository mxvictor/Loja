using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaTeste.Properties
{
    public class Produto
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public double Preço { get; set; }
        public int Quantidade { get; set; }

        public Produto(string iD, string nome, double preço, int quantidade)
        {
            ID = iD;
            Nome = nome;
            Preço = preço;
            Quantidade = quantidade;
        }

        public Produto()
        {

        }

        public override string ToString()
        {
            return "           |  " + ID + "  |   " + Nome + "     |    " + Preço + "     |    " + Quantidade + "     |    ";
        }
    }
}