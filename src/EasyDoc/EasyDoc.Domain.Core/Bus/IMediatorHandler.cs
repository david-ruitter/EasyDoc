using EasyDoc.Domain.Core.Commands;
using System.Threading.Tasks;

namespace EasyDoc.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommandAsync<T>(T command) where T : Command;
        Task SendRequestAsync<TResponse>(Request<TResponse> request);
    }
}
