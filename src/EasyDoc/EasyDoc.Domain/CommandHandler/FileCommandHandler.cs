using EasyDoc.Domain.Commands.Files;
using MediatR;
using System;
using System.IO;
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
            if (!request.IsValid())
            {
                request.PrintErrors();
                return Unit.Task;
            }

            string outputPath = request.FilePath ?? Directory.GetCurrentDirectory();
            outputPath += "documentation.txt";

            File.WriteAllText(outputPath, request.FileContent);

            return Unit.Task;
        }
    }
}
