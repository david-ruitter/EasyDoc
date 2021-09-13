using EasyDoc.Application.Models;
using System.Collections.Generic;

namespace EasyDoc.Application.Interfaces
{
    public interface IFormatService
    {
        string? FormatAs(CommentOutput content, string format);
        string? FormatAs(List<CommentOutput> content, string format);
    }
}
