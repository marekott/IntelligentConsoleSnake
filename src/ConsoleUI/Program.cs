using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public static class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70,30);

            using var serviceProvider = ContainerConfig.ConfigureServiceProvider();
            var menu = serviceProvider.GetService<Menu>();
            menu.DisplayMenu();
        }
    }
}
