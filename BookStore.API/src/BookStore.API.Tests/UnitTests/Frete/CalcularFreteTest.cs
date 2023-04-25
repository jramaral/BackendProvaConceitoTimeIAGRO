using BookStore.API.FreteCerto.CalcularFrete;
using Xunit;

namespace BookStore.API.Tests.UnitTests.Frete
{
    public class CalcularFreteTest
    {

        [Theory]
        [InlineData(100, 20)]
        [InlineData(50.75, 10.15)]
        [InlineData(0, 0)]
        public void DeveCalcularFreteTest_Corretamente(double valorDoLivro, double valorEsperado)
        {
            // Arrange
            FreteVintePorcento frete = new FreteVintePorcento();

            // Act
            double resultado = frete.CalcularFrete(valorDoLivro);

            // Assert
            Assert.Equal(valorEsperado, resultado);
        }
    }
}
