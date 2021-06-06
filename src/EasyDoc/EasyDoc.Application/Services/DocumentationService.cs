using EasyDoc.Application.Interfaces;
using EasyDoc.Application.Models;
using EasyDoc.Application.Requests.Documentation;
using EasyDoc.Application.Rules;
using EasyDoc.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoc.Application.Services
{
    public class DocumentationService : IDocumentationService
    {
        private readonly IMediatorHandler _bus;
        private Rules.Rules selectedRule;
        private readonly List<Rules.Rules> rules = new List<Rules.Rules>()
        {
            new JavaRules()
        };

        public DocumentationService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<CommentOutput> CreateDocumentationAsync(InputFile inputFile)
        {
            selectedRule = rules.FirstOrDefault(r => r.FileExtension == inputFile.Extension);
            if (selectedRule == null)
            {
                Console.WriteLine("The format " + inputFile.Extension + " does not exist");
                return null;
            }

            CommentOutput documentation = null;

            if (inputFile.Extension == ".java")
            {
                var request = new GetJavaDocumentation(Guid.NewGuid(), inputFile.Name, inputFile.Content);
                documentation = await _bus.SendReturningCommandAsync(request);
            }

            return documentation;
        }
    }
}
