using FluentValidation.Results;
using System;

namespace EasyDoc.Domain.Core.Commands
{
    public abstract class ReturningCommand<T> : Request<T>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected ReturningCommand(Guid aggregateId) : base(aggregateId)
        {
        }

        public abstract bool IsValid();
    }
}
