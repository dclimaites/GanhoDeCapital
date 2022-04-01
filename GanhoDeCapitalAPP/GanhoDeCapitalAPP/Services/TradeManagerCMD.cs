using AutoMapper;
using GanhoDeCapitalAPP.Domain;
using GanhoDeCapitalAPP.Domain.Interfaces;
using GanhoDeCapitalAPP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GanhoDeCapitalAPP.Services
{
    public class TradeManagerCMD : ITradeManager
    {
        public IMapper Mapper { get; }

        public TradeManagerCMD(IMapper mapper)
        {
            Mapper = mapper;
        }
        public void Run()
        {

            bool restart = true;
            do
            {
                Console.WriteLine("Entre com as informações de análise de Transações");

                var inputs = Console.ReadLine();
                if (string.IsNullOrEmpty(inputs))
                    restart = false;
                else
                    Console.WriteLine(ReadInputs(inputs));

            } while (restart);
        }

        public string ReadInputs(string input)
        {
            //Converter JSON
            var transactionsDto = JsonSerializer.Deserialize<IEnumerable<TransctionDTO>>(input);
            var transactions = Mapper.Map<IEnumerable<Transaction>>(transactionsDto);
            var trade = new Trade(transactions);
            decimal losses = 0m;
            List<Tax> taxes = new List<Tax>();
            foreach (var item in transactions)
            {
                var averagePrice = trade.CalculateAveragePrice(item);
                losses += trade.Loss(item);
                var tax = new Tax(item, trade);
                var tese = tax.CalculateTax();
                taxes.Add(tax);
            }

            var taxesDto = Mapper.Map<IEnumerable<TaxDTO>>(taxes);

            return JsonSerializer.Serialize(taxesDto);
        }
    }
}
