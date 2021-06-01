using EasyDoc.Application.Interfaces;
using EasyDoc.Domain.Commands.Files;
using EasyDoc.Domain.Core.Bus;
using System;
using System.Threading.Tasks;

namespace EasyDoc.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IMediatorHandler _bus;

        public FileService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task WriteFile()
        {
            await _bus.SendCommandAsync(new WriteFileCommand(Guid.NewGuid(), "Test.txt", null));
            throw new NotImplementedException();
        }
    }
}
