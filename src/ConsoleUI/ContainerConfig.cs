using System.IO;
using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnakeAI;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static ServiceProvider ConfigureServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton(LoadConfiguration())
                .AddSingleton<IConfigProvider, ConfigProvider>()
                .AddScoped<IGameCreator, GameCreator>()
                .AddSingleton<IDisplay, Display>()
                .AddScoped<IGameControllerCreator, GameControllerCreator>()
                .AddScoped<ISnakeBot, SnakeBot>()
                .AddScoped<Menu>()
                .AddScoped<SnakeAIModel>()
                .AddScoped<ModelInputHelper>()
                .BuildServiceProvider();
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
                
            return builder.Build();
        }
    }
}
