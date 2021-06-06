using EasyDoc.Application.Models;
using System.Threading.Tasks;

namespace EasyDoc.Application.Interfaces
{
    public interface IDocumentationService
    {
        Task<string> CreateDocumentationAsync(InputFile inputFile, string outputFormat);
    }
}
