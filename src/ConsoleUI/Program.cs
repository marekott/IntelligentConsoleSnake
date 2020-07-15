using System;
using Autofac;

namespace ConsoleUI
{
    public static class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70,30);

            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var menu = scope.Resolve<Menu>();
                menu.DisplayMenu();
            }
        }
    }
}
