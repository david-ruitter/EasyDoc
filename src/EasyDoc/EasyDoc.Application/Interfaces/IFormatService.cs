using EasyDoc.Application.Models;

namespace EasyDoc.Application.Interfaces
{
    public interface IFormatService
    {
        string FormatAs(CommentOutput content, string format);
    }
}
