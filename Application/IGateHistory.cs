using App.Application.ICommand;

namespace App.Application
{
    public interface IGateHistory
    {
        void Register(ICommand command);
    }
}
