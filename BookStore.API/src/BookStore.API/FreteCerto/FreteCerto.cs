using BookStore.API.FreteCerto.Frete;

namespace BookStore.API.FreteCerto
{
    public class FreteCerto
    {
        private IFrete _frete;

        public FreteCerto(IFrete frete)
        {
            _frete = frete;
        }

        public double CalcularFrete(double valorDoLivro)
        {
            return _frete.CalcularFrete(valorDoLivro);
        }
    }
}
