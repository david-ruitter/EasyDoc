using EasyDoc.Application.Interfaces;
using EasyDoc.Domain.Commands.Files;
using EasyDoc.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyDoc.Application.Services
{
    public class FileOutputService : IFileOutputService
    {
        private readonly IMediatorHandler _bus;

        public FileOutputService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task WriteFile(List<string> documentations, string outputPath)
        {
            foreach(var doc in documentations)
            {
                if (doc != null)
                {
                    await _bus.SendCommandAsync(new WriteFileCommand(Guid.NewGuid(), doc, "Test.txt", outputPath));
                }
            }
        }

        public async Task WriteFile(string documentation, string outputPath)
        {
            await _bus.SendCommandAsync(new WriteFileCommand(Guid.NewGuid(), documentation, "Test.txt", outputPath));
        }
    }
}
