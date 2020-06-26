using MarsRover.Application;
using MarsRover.Application.Surface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class TestBase
    {
        private ServiceProvider serviceProvider;

        protected ISurface surface;
        protected ICommandManager commandManager;
        protected IRoverManager roverManager;

        [SetUp]
        public void Setup()
        {
            serviceProvider = new ServiceCollection()
                .AddSingleton<IHandler, PlataueHandler>()
                .AddSingleton<IHandler, PositionHandler>()
                .AddSingleton<IHandler, RoverHandler>()
                .AddSingleton<ISurface, PlateauSurface>()
                .AddSingleton<ICommandManager, CommandManager>()
                .AddSingleton<IRoverManager, RoverManager>()
                .BuildServiceProvider();

            surface = (ISurface)serviceProvider.GetService(typeof(ISurface));
            commandManager = (ICommandManager)serviceProvider.GetService(typeof(ICommandManager));
            roverManager = (IRoverManager)serviceProvider.GetService(typeof(IRoverManager));
        }
    }
}
