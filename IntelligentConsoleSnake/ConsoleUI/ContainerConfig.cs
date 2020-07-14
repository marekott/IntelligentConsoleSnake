using Autofac;
using ConsoleUI.Configuration;
using ConsoleUI.FactoryMethods;
using SnakeGame.Interfaces;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConfigProvider>().As<IConfigProvider>().SingleInstance();
            builder.RegisterType<GameCreator>().As<IGameCreator>();
            builder.RegisterType<Display>().As<IDisplay>().SingleInstance();
            builder.RegisterType<GameControllerCreator>().As<IGameControllerCreator>();
            builder.RegisterType<Menu>();

            return builder.Build();
        }
    }
}
