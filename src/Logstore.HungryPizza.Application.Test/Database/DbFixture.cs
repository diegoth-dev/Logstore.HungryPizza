using Logstore.HungryPizza.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logstore.HungryPizza.Application.Test.Database
{
    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; }
        public ConfigurationBuilder Configuration { get; set; }
        public DbFixture()
        {
            var services = new ServiceCollection();
            Configuration = new ConfigurationBuilder();
            Configuration.AddJsonFile("appsettings.json");
            IConfiguration configuration = Configuration.Build();
            RegisterServices(services, configuration);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var app = new Startup(configuration);
            app.ConfigureServices(services);
            services.AddSingleton(configuration);
        }
    }
}