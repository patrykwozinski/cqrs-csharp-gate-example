using App.Application.ICommand;
using App.Application.IGateHistory;
using App.Application.DuplicatedCommandException;

namespace App.Application
{
    public interface IGate
    {
        public void Dispatch(ICommand command);
    }

    public class Gate : IGate
    {
        private readonly IGateHistory _gateHistory;

        public Gate(IGateHistory gateHistory)
        {
            _gateHistory = gateHistory;
        }

        public void Dispatch(ICommand command)
        {
            try
            {
                _gateHistory.register(command);
            }
            catch (DuplicatedCommandException)
            {
                // This should be logger with info about duplicated command

                return;
            }
        }
    }
}
