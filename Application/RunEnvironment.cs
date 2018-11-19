using App.Application.ICommand;
using App.Application.ICommandHandler;
using App.Application.CommandHandlerProvider;

namespace App.Application
{
    public class RunEnvironment
    {
        private readonly CommandHandlerProvider _commandHandlerProvider;

        public RunEnvironment(CommandHandlerProvider commandHandlerProvider)
        {
            _commandHandlerProvider = commandHandlerProvider;
        }

        public void Run(ICommand command)
        {
            ICommandHandler handler = _commandHandlerProvider.handlerFor(command);

            handler.handle(command);
        }
    }
}
