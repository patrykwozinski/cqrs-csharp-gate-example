using App.Application.ICommand;
using App.Application.IGateHistory;
using App.Application.DuplicatedCommandException;
using App.Application.RunEnvironment;
using App.Application.Asynchronous;
using App.Application.IQueue;

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

        private readonly IQueue _queue;

        public Gate(IGateHistory gateHistory, RunEnvironment runEnvironment, IQueue queue)
        {
            _gateHistory = gateHistory;
            _runEnvironment = runEnvironment;
            _queue = queue;
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

            if (command is Asynchronous)
            {
                // Queue should pass command to RunEnvironment
                _queue.push(command);

                return;
            }

            _runEnvironment.run(command);
        }
    }
}
