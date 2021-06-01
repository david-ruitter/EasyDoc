using MediatR;
using System;

namespace EasyDoc.Domain.Core.Commands
{
    public class Request : IRequest
    {
        public Guid AggregateId { get; }
        public string MessageType { get; }

        protected Request(Guid aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
        }
    }

    public class Request<T> : IRequest<T>
    {
        public Guid AggregateId { get; }
        public string MessageType { get; }

        protected Request(Guid aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
        }
    }
}
