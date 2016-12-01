using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace testselfcontained
{
    public class Program
    {
        public static void Main(string[] args)
        {               
            var host = new WebHostBuilder()
                .UseKestrel(options => { options.AddServerHeader = false; })
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Production")
                .ConfigureServices(services =>
                {
                    services.AddResponseCompression();
                    services.AddMvc();
                })
                .Configure(app =>
                {
                    app.UseResponseCompression();
                    app.UseMvcWithDefaultRoute();
                }).Build();
            host.Run();
        }
    }
}