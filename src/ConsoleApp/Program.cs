using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var serviceProviderBuilder = new ServiceCollection()
                .AddScoped(provider => configuration);

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (!string.IsNullOrEmpty(configuration["DATABASE_HOST"]) &&
                !string.IsNullOrEmpty(configuration["DATABASE_PORT"]))
            {
                connectionString = connectionString.Replace("dbuser", configuration["DATABASE_USER"]);
                connectionString = connectionString.Replace("dbpass", configuration["DATABASE_PASSWORD"]);
                connectionString = connectionString.Replace("dbhost", configuration["DATABASE_HOST"]);
                connectionString = connectionString.Replace("dbport", configuration["DATABASE_PORT"]);
                connectionString = connectionString.Replace("dbname", configuration["DATABASE_NAME"]);
            }

            serviceProviderBuilder.AddDbContext<MyDbContext>(dbOptions =>
            {
                dbOptions.UseNpgsql(connectionString);
            });

            serviceProviderBuilder.AddScoped<IApplication, Application>();
            serviceProviderBuilder.AddTransient<MyDbContextInitializer>();

            var serviceProvider = serviceProviderBuilder.BuildServiceProvider();


            using (var scope = serviceProvider.CreateScope())
            {
                var dbInit = scope.ServiceProvider.GetRequiredService<MyDbContextInitializer>();
                dbInit.ExecuteMigrations();

                var app = scope.ServiceProvider.GetRequiredService<IApplication>();
                app.Run();
            }
        }
    }
}
