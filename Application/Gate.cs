using Application.ICommand;

namespace App.Application
{
    public interface IGate
    {
        public void dispatch(ICommand command);
    }
}
