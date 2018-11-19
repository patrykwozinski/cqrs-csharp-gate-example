using App.Application.ICommand;

namespace App.Application.Exception
{
    public class DuplicatedCommandException : System.Exception
    {
        public static DuplicatedCommandException forCommand(ICommand command)
        {
            // @TODO: To implement
        }
    }
}
