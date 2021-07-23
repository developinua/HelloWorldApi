using System.Collections.Generic;
using HelloWorldApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace HelloWorldApiTest
{
    public class StartupTest
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Mock<IHelloWorldService> mockHelloWorldService = new();
            mockHelloWorldService.Setup(x => x.GetHelloWorlds())
                .Returns(new List<string> { "Hello World!" });

            services.AddTransient(_ => mockHelloWorldService.Object);
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}