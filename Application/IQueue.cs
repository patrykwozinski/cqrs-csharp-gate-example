using App.Application.ICommand;

namespace App.Application
{
    public interface IQueue
    {
        void push(ICommand command);
    }
}
