namespace EasyDoc.Application.Models
{
    public record InputFile(string Path, string Name, string Extension, string Content = "");
}
