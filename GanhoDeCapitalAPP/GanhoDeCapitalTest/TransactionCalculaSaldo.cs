using GanhoDeCapitalAPP.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GanhoDeCapitalTest
{
    public class TransactionCalculaSaldo
    {
        public static IEnumerable<Transaction> Transactions = new List<Transaction>()
        {
            new Transaction("buy", 10m, 10000),
            new Transaction("sell", 20m, 5000)
        };
        
        public static IEnumerable<Transaction> TransacoesComPrejuizo = new List<Transaction>()
        {
            new Transaction("buy", 10m, 10000),
            new Transaction("sell", 9m, 5000)
        };

        public static IEnumerable<object[]> TransacoesComLucro()
        {
            yield return new object[] {
                Transactions.Last()
                , Transactions
                ,50000m

            };
        }

        public static IEnumerable<object[]> TransacoesSemLucro()
        {
            yield return new object[] {
                TransacoesComPrejuizo.Last()
                , TransacoesComPrejuizo
                ,-5000m
            };
        }

        [Theory]
        [MemberData(nameof(TransacoesComLucro))]
        [MemberData(nameof(TransacoesSemLucro))]
        public void CalculaSaldoDadoTransacaoComLucro(Transaction transacaoSobAnalise, IEnumerable<Transaction> transacoes, decimal valorEsperado)
        {
            //arrange
            var trade = new Trade(transacoes);
            //act
            var saldo = trade.Balance(transacaoSobAnalise);
            //assert
            Assert.Equal(valorEsperado, saldo);

        }
    }
}
