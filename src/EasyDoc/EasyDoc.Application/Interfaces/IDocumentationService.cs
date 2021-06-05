using EasyDoc.Application.Models;

namespace EasyDoc.Application.Interfaces
{
    public interface IDocumentationService
    {
        string CreateDocumentation(InputFile inputFile, string outputFormat);
    }
}
