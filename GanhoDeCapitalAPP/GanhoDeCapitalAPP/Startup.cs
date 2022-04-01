using AutoMapper;
using GanhoDeCapitalAPP.Domain;
using GanhoDeCapitalAPP.DTO;
using GanhoDeCapitalAPP.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GanhoDeCapitalAPP
{
    public static class Startup
    {
        public static IHost AppStartup()
        {
            var configuration = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TransctionDTO, Transaction>()
                    .ForCtorParam("operation", opt => opt.MapFrom(src => src.Operation))
                    .ForCtorParam("unitCost", opt => opt.MapFrom(src => src.UnitCost))
                    .ForCtorParam("quantity", opt => opt.MapFrom(src => src.Quantity))
                    .ReverseMap();

                cfg.CreateMap<Tax, TaxDTO>()
                    .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.CalculateTax()));
            });
            configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = configuration.CreateMapper();

            

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(mapper);
                    services.AddTransient<ITradeManager, TradeManagerCMD>();
                })
                .Build();

            return host;
        }
    }
}
