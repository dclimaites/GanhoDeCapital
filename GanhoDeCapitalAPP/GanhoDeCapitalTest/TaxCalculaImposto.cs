using GanhoDeCapitalAPP.Domain;
using System.Collections.Generic;
using Xunit;

namespace GanhoDeCapitalTest
{
    public class TaxCalculaImposto
    {
        public static IEnumerable<object[]> TransacoesComLucro()
        {
            yield return new object[] {
                new Transaction("sell", 20m, 11000, 9m)
                , 9m
                //, new List<Transaction>()
                //{
                //    new Transaction("buy", 10m, 10000, 10m),
                //    new Transaction("sell", 20m, 5000, 10m)
                //}
                ,24200m

            };
        }

        public static IEnumerable<object[]> TransacoesSemLucro()
        {
            yield return new object[] {
                new Transaction("sell", 9m, 100, 10m)
                , 9m
                //, new List<Transaction>()
                //{
                //    new Transaction("buy", 10m, 10000, 10m),
                //    new Transaction("sell", 20m, 5000, 10m)
                //}
                ,0m

            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComLucro))]
        [MemberData(nameof(TransacoesSemLucro))]
        public void CalculaImpostoDadoTransacaoComLucro(Transaction transacaoSobAnalise, decimal precoMedio, decimal valorEsperado)
        {
            //arrange
            var regra = new Tax(transacaoSobAnalise, precoMedio);
            //act
            var imposto = regra.CalculateTax();
            //assert
            Assert.Equal(valorEsperado, imposto);

        }
    }
}
