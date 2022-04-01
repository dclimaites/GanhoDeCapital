using GanhoDeCapitalAPP.Domain;
using System.Collections.Generic;
using System.Linq;
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
                    new Transaction("buy", 10.00m, 100),
                    new Transaction("buy", 12.00m, 100),
                    new Transaction("sell", 14.00m, 100),
                    new Transaction("buy", 11.00m, 100),
                },11.00m

            };
        }
        
        public static IEnumerable<object[]> TransacoesCaso2()
        {
            yield return new object[] { 
                new List<Transaction>()
                {
                    new Transaction("buy", 10.00m, 10000),
                    new Transaction("sell", 20.00m, 5000),
                    new Transaction("sell", 5.00m, 5000),
                },10.00m

            };
        }

        public static IEnumerable<object[]> TransacoesSemVenda()
        {
            yield return new object[] { 
                new List<Transaction>()
                {
                    new Transaction("buy", 10.25m, 75),
                    new Transaction("buy", 12.00m, 50),
                    new Transaction("buy", 09.50m, 100),
                    new Transaction("buy", 11.33m, 100),
                },
                10.62m
            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComVenda))]
        [MemberData(nameof(TransacoesSemVenda))]
        [MemberData(nameof(TransacoesCaso2))]
        public void CalculaPrecoMedioDadoTransacoesComCompra(IEnumerable<Transaction> transacoes, decimal valorEsperado)
        {
            //arrange
            var operacao = new Trade(transacoes);
            //act
            var precoMedioCalculado = operacao.CalculateAveragePrice(transacoes.Last());
            //assert
            Assert.Equal(valorEsperado, precoMedioCalculado);
            
        }
    }
}
