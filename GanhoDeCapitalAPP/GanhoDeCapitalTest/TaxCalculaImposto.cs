using GanhoDeCapitalAPP.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GanhoDeCapitalTest
{
    public class TaxCalculaImposto
    {
        public static List<Transaction> ListaTransacoes = new List<Transaction>() { 
            new Transaction("buy", 10m, 10000) //0
            , new Transaction("sell", 2m, 5000) //1 
            , new Transaction("sell", 20m, 2000) //2
            , new Transaction("sell", 20m, 2000) //3
            , new Transaction("sell", 25m, 1000) //4
            , new Transaction("buy", 20m, 10000) //5
            , new Transaction("sell", 5m, 5000) //6
            , new Transaction("sell", 30m, 4350) //7
            , new Transaction("sell", 30m, 650) //8
        };
        public static IEnumerable<object[]> TransacaoComLucroEImpostoASerPago()
        {
            yield return new object[] {
                ListaTransacoes.ElementAt(4)
                , new Trade(ListaTransacoes)
                ,3000m

            };
        }
        public static IEnumerable<object[]> TransacaoComLucroEPrejuizoDedutivel()
        {
            yield return new object[] {
                ListaTransacoes.ElementAt(3)
                , new Trade(ListaTransacoes)
                ,0m

            };
        }

        [Theory]
        //[MemberData(nameof(TransacaoComLucroEImpostoASerPago))]
        [MemberData(nameof(TransacaoComLucroEPrejuizoDedutivel))]
        public void CalculaImpostoDadoTransacaoComLucro(Transaction transacaoSobAnalise, Trade trade, decimal valorEsperado)
        {
            //arrange
            var regra = new Tax(transacaoSobAnalise, trade);
            //act
            var imposto = regra.CalculateTax();
            //assert
            Assert.Equal(valorEsperado, imposto);
        }

        //[Theory]
        //[MemberData(nameof(TransacoesComLucroEPrejuizoAcumulado))]
        //[MemberData(nameof(TransacoesSemLucroEPrejuizoAcumulado))]
        //[MemberData(nameof(TransacoesComLucroInferiroAoPrejuizoAcumulado))]
        //[MemberData(nameof(TransacoesComLucroIgualAoPrejuizoAcumulado))]
        //[MemberData(nameof(TransacoesComLucroSuperiorAoPrejuizoAcumulado))]
        //public void CalculaImpostoDadoTransacaoComPrejuizoAcumulado(Transaction transacaoSobAnalise, Trade trade, decimal prejuizoAcumulado, decimal valorEsperado)
        //{
        //    //arrange
        //    var regra = new Tax(transacaoSobAnalise, trade, prejuizoAcumulado);
        //    //act
        //    var imposto = regra.CalculateTax();
        //    //assert
        //    Assert.Equal(valorEsperado, imposto);
        //}
    }
}
