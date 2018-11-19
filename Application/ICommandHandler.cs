namespace App.Application
{
    public interface ICommandHandler
    {
        void handle(ICommand command);
    }
}
