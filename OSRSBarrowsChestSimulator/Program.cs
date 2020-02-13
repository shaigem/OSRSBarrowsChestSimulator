using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSRSBarrowsChestSimulator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);


            builder.Services.AddSingleton<StoreContext>();
            builder.Services.AddSingleton<BarrowsBrotherService>();
            builder.Services.AddSingleton<RewardItemDefinitionService>();
            builder.Services.AddSingleton<RewardChestService>();


            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            var store = host.Services.GetRequiredService<StoreContext>();
            var httpClient = host.Services.GetRequiredService<HttpClient>();

            await SeedBarrowsData.Initialize(store, httpClient);

            await host.RunAsync();
        }
    }
}
