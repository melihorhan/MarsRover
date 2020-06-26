using MarsRover.Application;
using MarsRover.Application.Surface;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Host.Configuration
{
    public class ApplicationConfiguration
    {
        internal static ServiceProvider BuildService()
        {
            return new ServiceCollection()
                .AddSingleton<IHandler, PlataueHandler>()
                .AddSingleton<IHandler, PositionHandler>()
                .AddSingleton<IHandler, RoverHandler>()
                .AddSingleton<ISurface, PlateauSurface>()
                .AddSingleton<ICommandManager, CommandManager>()
                .AddSingleton<IRoverManager, RoverManager>()
                .BuildServiceProvider();
        }
    }
}
