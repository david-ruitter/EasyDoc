using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyDoc.Application.Interfaces
{
    public interface IFileOutputService
    {
        Task WriteFile(string documentation, string outputPath, string outfile = "documentation.txt");
        Task WriteFile(List<string> documentations, string outputPath, string outfile = "documentation.txt");
    }
}
