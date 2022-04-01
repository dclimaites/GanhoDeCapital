using GanhoDeCapitalAPP.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GanhoDeCapitalAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Startup.AppStartup();

            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var manager = provider.GetRequiredService<ITradeManager>();

            manager.Run();
        }
    }
}
