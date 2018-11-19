using App.Application.ICommand;
using App.Application.IGateHistory;
using App.Application.DuplicatedCommandException;
using App.Application.RunEnvironment;

namespace App.Application
{
    public interface IGate
    {
        public void Dispatch(ICommand command);
    }

    public class Gate : IGate
    {
        private readonly IGateHistory _gateHistory;

        private readonly RunEnvironment _runEnvironment;

        public Gate(IGateHistory gateHistory, RunEnvironment runEnvironment)
        {
            _gateHistory = gateHistory;
            _runEnvironment = runEnvironment;
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

            _runEnvironment.run(command);
        }
    }
}
