using EasyDoc.Domain.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace EasyDoc.Domain.Core.Bus
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendCommandAsync<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(Request<TResponse> request)
        {
            return await _mediator.Send(request);
        }

        public async Task<TResponse> SendReturningCommandAsync<TResponse>(ReturningCommand<TResponse> command)
        {
            return await _mediator.Send(command);
        }
    }
}
