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

        public static IEnumerable<object[]> TransacoesComLucroEPrejuizoAcumulado()
        {
            yield return new object[] {
                new Transaction("sell", 12m, 100, 10m)
                , 10m
                , 2000m
                , 0m

            };
        }

        public static IEnumerable<object[]> TransacoesSemLucroEPrejuizoAcumulado()
        {
            yield return new object[] {
                new Transaction("sell", 9m, 100, 10m)
                , 10m
                , 2000m
                , 0
            };
        }
        public static IEnumerable<object[]> TransacoesComLucroInferiroAoPrejuizoAcumulado()
        {
            yield return new object[] {
                new Transaction("sell", 15m, 100, 10m)
                , 10m
                , 2000m
                , 0
            };
        }

        public static IEnumerable<object[]> TransacoesComLucroIgualAoPrejuizoAcumulado()
        {
            yield return new object[] {
                new Transaction("sell", 15m, 400, 10m)
                , 10m
                , 2000m
                , 0
            };
        }

        public static IEnumerable<object[]> TransacoesComLucroSuperiorAoPrejuizoAcumulado()
        {
            yield return new object[] {
                new Transaction("sell", 15m, 5000, 10m)
                , 10m
                , 20000m
                , 1000m
            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComLucro))]
        [MemberData(nameof(TransacoesSemLucro))]
        public void CalculaImpostoDadoTransacaoComLucro(Transaction transacaoSobAnalise, decimal precoMedio, decimal valorEsperado)
        {
            //arrange
            var regra = new Tax(transacaoSobAnalise, precoMedio, 0);
            //act
            var imposto = regra.CalculateTax();
            //assert
            Assert.Equal(valorEsperado, imposto);

        }

        [Theory]
        [MemberData(nameof(TransacoesComLucroEPrejuizoAcumulado))]
        [MemberData(nameof(TransacoesSemLucroEPrejuizoAcumulado))]
        [MemberData(nameof(TransacoesComLucroInferiroAoPrejuizoAcumulado))]
        [MemberData(nameof(TransacoesComLucroIgualAoPrejuizoAcumulado))]
        [MemberData(nameof(TransacoesComLucroSuperiorAoPrejuizoAcumulado))]
        public void CalculaImpostoDadoTransacaoComPrejuizoAcumulado(Transaction transacaoSobAnalise, decimal precoMedio, decimal prejuizoAcumulado, decimal valorEsperado)
        {
            //arrange
            var regra = new Tax(transacaoSobAnalise, precoMedio, prejuizoAcumulado);
            //act
            var imposto = regra.CalculateTax();
            //assert
            Assert.Equal(valorEsperado, imposto);
        }
    }
}
