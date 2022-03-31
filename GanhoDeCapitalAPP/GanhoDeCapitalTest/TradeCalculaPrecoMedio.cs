using GanhoDeCapitalAPP.Domain;
using System.Collections.Generic;
using Xunit;

namespace GanhoDeCapitalTest
{
    public class TradeCalculaPrecoMedio
    {
        public static IEnumerable<object[]> TransacoesComVenda()
        {
            yield return new object[] { 
                new List<Transaction>()
                {
                    new Transaction("buy", 10.00m, 100, 11.00m),
                    new Transaction("buy", 12.00m, 100, 11.00m),
                    new Transaction("sell", 14.00m, 100, 11.00m),
                    new Transaction("buy", 11.00m, 100, 11.00m),
                },11.00m

            };
        }

        public static IEnumerable<object[]> TransacoesSemVenda()
        {
            yield return new object[] { 
                new List<Transaction>()
                {
                    new Transaction("buy", 10.25m, 75, 10.62m),
                    new Transaction("buy", 12.00m, 50, 10.62m),
                    new Transaction("buy", 09.50m, 100, 10.62m),
                    new Transaction("buy", 11.33m, 100, 10.62m),
                },
                10.62m
            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComVenda))]
        [MemberData(nameof(TransacoesSemVenda))]
        public void CalculaPrecoMedioDadoTransacoesComCompra(IEnumerable<Transaction> transacoes, decimal valorEsperado)
        {
            //arrange
            var operacao = new Trade(transacoes);
            //act
            var precoMedioCalculado = operacao.CalculateAveragePrice();
            //assert
            Assert.Equal(valorEsperado, precoMedioCalculado);
            
        }
    }
}