using System;
using MarsRover.Application;
using MarsRover.Application.Surface;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHandler, PlataueHandler>()
                .AddSingleton<IHandler, PositionHandler>()
                .AddSingleton<IHandler, RoverHandler>()
                .AddSingleton<ISurface, PlateauSurface>()
                .AddSingleton<ICommandManager, CommandManager>()
                .AddSingleton<IRoverManager, RoverManager>()
                .BuildServiceProvider();


            var commandManager = (ICommandManager)serviceProvider.GetService(typeof(ICommandManager));

            commandManager.Send("5 5");

            commandManager.Send("1 2 N");
            commandManager.Send("LMLMLMLMM");

            commandManager.Send("3 3 E");
            commandManager.Send("MMRMMRMRRM");

            var roverManager = (IRoverManager)serviceProvider.GetService(typeof(IRoverManager));

            foreach (var rover in roverManager.Rovers)
            {
                Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction}");
            }

            Console.ReadKey();
        }
    }
}
