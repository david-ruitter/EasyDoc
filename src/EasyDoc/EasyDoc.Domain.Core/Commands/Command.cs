using System;
using FluentValidation.Results;

namespace EasyDoc.Domain.Core.Commands
{
    public abstract class Command : Request
    {
        public DateTimeOffset TimeStamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Command(Guid aggregateId) : base(aggregateId)
        {
            TimeStamp = DateTimeOffset.Now;
        }

        public abstract bool IsValid();
    }
}
