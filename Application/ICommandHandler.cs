using App.Application.ICommand;

namespace App.Application
{
    public interface ICommandHandler
    {
        void handle(ICommand command);
    }
}
