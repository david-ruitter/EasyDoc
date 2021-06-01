using EasyDoc.Domain.Commands.Files;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyDoc.Domain.CommandHandler
{
    public class FileCommandHandler : IRequestHandler<WriteFileCommand>
    {
        public FileCommandHandler()
        {
        }

        public Task<Unit> Handle(WriteFileCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("WriteFileCommand was triggered! Filename = " + request.FileName);
            return Unit.Task;
        }
    }
}
