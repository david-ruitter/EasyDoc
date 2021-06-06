using EasyDoc.Domain.Core.Commands;
using System.Threading.Tasks;

namespace EasyDoc.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommandAsync<T>(T command) where T : Command;
        Task<TResponse> SendRequestAsync<TResponse>(Request<TResponse> request);
        Task<TResponse> SendReturningCommandAsync<TResponse>(ReturningCommand<TResponse> command);
    }
}
