using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace HelloWorldApiTest
{
    public class WebApiTestFactory : WebApplicationFactory<StartupTest>
    {
        protected override IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder =>
                    builder.UseStartup<StartupTest>());
    }
}
