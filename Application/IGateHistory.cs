namespace App.Application
{
    public interface IGateHistory
    {
        void Register(ICommand command);
    }
}
