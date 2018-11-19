using App.Application.ICommand;

namespace App.Application
{
    public interface IGateHistory
    {
        public void Register(ICommand command);
    }
}
