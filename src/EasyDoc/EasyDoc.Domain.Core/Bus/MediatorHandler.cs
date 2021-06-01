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

        public async Task SendRequestAsync<TResponse>(Request<TResponse> request)
        {
            await _mediator.Send(request);
        }
    }
}
