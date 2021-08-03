using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using password_verifier.Services;

namespace password_verifier
{
    public class Program
    {
        public static string baseAddress;
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            builder.Services.AddSingleton(sp => new HttpClient());

            builder.Services.AddSingleton<ReviewsService>();

            baseAddress = new Uri(builder.HostEnvironment.BaseAddress).ToString();
            
            await builder.Build().RunAsync();
        }
    }
}
