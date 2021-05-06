using ABAPAI.Domain.Interfaces.Commands;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
