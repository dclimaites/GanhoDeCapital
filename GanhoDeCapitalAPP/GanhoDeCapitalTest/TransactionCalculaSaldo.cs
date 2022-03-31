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
                , new List<Transaction>()
                {
                    new Transaction("buy", 10m, 10000, 10m),
                    new Transaction("sell", 20m, 5000, 10m)
                }
                ,50000m

            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComLucro))]
        public void CalculaPrecoMedioDadoTransacoesComCompra(Transaction transacaoSobAnalise, IEnumerable<Transaction> transacoes, decimal valorEsperado)
        {
            //arrange
            var trade = new Trade(transacoes);
            //act
            var saldo = transacaoSobAnalise.Balance();
            //assert
            Assert.Equal(valorEsperado, saldo);

        }
    }
}
