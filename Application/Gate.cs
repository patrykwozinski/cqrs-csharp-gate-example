using App.Application.ICommand;
using App.Application.IGateHistory;

namespace App.Application
{
    public interface IGate
    {
        public void Dispatch(ICommand command);
    }

    public class Gate
    {
        private readonly IGateHistory _gateHistory;

        public Gate(IGateHistory gateHistory)
        {
            _gateHistory = gateHistory;
        }
    }
}
