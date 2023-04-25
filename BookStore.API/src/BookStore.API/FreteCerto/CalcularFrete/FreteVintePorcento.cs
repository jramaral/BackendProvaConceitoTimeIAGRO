using BookStore.API.FreteCerto.Frete;
using System.Drawing;

namespace BookStore.API.FreteCerto.CalcularFrete
{
    public class FreteVintePorcento : IFrete
    {

        public double CalcularFrete(double valorDoLivro)
        {
            return Math.Round(valorDoLivro * 0.2,2);
        }

    }
}
