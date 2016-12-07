using System;
using System.Threading.Tasks;

namespace Warden.Common.Handlers
{
    public interface IHandler
    {
        IHandlerTask Run(Action action);
        IHandlerTask Run(Func<Task> actionAsync);
        void ExecuteAll();
        Task ExecuteAllAsync();
    }
}