using GanhoDeCapitalAPP.Domain;
using System.Collections.Generic;
using Xunit;

namespace GanhoDeCapitalTest
{
    public class TransactionCalculaSaldo
    {
        public static IEnumerable<object[]> TransacoesComLucro()
        {
            yield return new object[] {
                new Transaction("sell", 20m, 5000, 10m)
                ,50000m

            };
        }

        public static IEnumerable<object[]> TransacoesSemLucro()
        {
            yield return new object[] {
                new Transaction("sell", 9m, 5000, 10m)
                ,-5000m
            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComLucro))]
        [MemberData(nameof(TransacoesSemLucro))]
        public void CalculaSaldoDadoTransacaoComLucro(Transaction transacaoSobAnalise, decimal valorEsperado)
        {
            //arrange
            //var trade = new Trade(transacoes);
            //act
            var saldo = transacaoSobAnalise.Balance();
            //assert
            Assert.Equal(valorEsperado, saldo);

        }
    }
}
