using ABAPAI.Domain.Interfaces.Commands;

namespace ABAPAI.Domain.Interfaces.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
