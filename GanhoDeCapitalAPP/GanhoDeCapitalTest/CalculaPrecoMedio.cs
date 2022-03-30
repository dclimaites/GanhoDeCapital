using GanhoDeCapitalAPP.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GanhoDeCapitalTest
{
    public class CalculaPrecoMedio
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
                },11.25m

            };
        }

        public static IEnumerable<object[]> TransacoesSemVenda()
        {
            yield return new object[] { new List<Transaction>()
            {
                new Transaction("buy", 10.00m, 100),
                new Transaction("buy", 12.00m, 100),
                new Transaction("sell", 10.50m, 100),
                new Transaction("buy", 11.00m, 100),
            }};
        }

        [Theory]
        [MemberData(nameof(TransacoesComVenda))]
        public void CalculaPrecoMedioDadoTransacoesComCompra(IEnumerable<Transaction> transacoes, decimal valorEsperado)
        {
            //arrange
            var operacao = new Tax(transacoes);
            //act
            var precoMedioCalculado = operacao.CalculatePM();
            //assert
            Assert.Equal(precoMedioCalculado, valorEsperado);
            
        }
    }
}
