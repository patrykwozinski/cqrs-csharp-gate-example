using App.Application.ICommand;
using App.Application.ICommandHandler;
using App.Application.CommandHandlerProvider;
using App.Application.ITransaction;

namespace App.Application
{
    public class RunEnvironment
    {
        private readonly CommandHandlerProvider _commandHandlerProvider;

        private readonly ITransaction _transaction;

        public RunEnvironment(CommandHandlerProvider commandHandlerProvider, ITransaction transaction)
        {
            _commandHandlerProvider = commandHandlerProvider;
            _transaction = transaction;
        }

        public void Run(ICommand command)
        {
            ICommandHandler handler = _commandHandlerProvider.handlerFor(command);

            _transaction.begin();

            try
            {
                handler.handle(command);

                _transaction.commit();
            }
            catch (System.Exception)
            {
                _transaction.rollback();
                
                throw;
            }
        }
    }
}
