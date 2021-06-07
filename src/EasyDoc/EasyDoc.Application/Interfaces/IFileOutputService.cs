using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyDoc.Application.Interfaces
{
    public interface IFileOutputService
    {
        Task WriteFile(List<string> documentations, string outputPath);
    }
}
