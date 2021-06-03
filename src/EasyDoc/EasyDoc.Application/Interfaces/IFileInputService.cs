using EasyDoc.Application.Models;
using System.Collections.Generic;

namespace EasyDoc.Application.Interfaces
{
    public interface IFileInputService
    {
        List<string[]> GetFilePaths(List<string> folderPaths);
        List<InputFile> ReadFiles(List<string[]> folders);
    }
}
