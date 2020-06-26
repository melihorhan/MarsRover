using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Application
{
    public class CommandManager : ICommandManager
    {
        private readonly IEnumerable<IHandler> handlers;

        public CommandManager(IEnumerable<IHandler> handlers)
        {
            this.handlers = handlers;
        }

        void ICommandManager.Send(string command)
        {
            var handler = handlers.SingleOrDefault(h => h.Match(command));
            handler?.Run(command);
        }
    }
}
