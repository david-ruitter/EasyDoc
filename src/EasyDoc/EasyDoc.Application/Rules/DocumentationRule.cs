using System.Collections.Generic;

namespace EasyDoc.Application.Rules
{
    public abstract class DocumentationRule
    {
        public string FileExtension { get; set; }
        public string StartOfComment { get; set; }
        public string EndOfComment { get; set; }
        public List<string> CommentTags { get; set; }

        public abstract bool IsStartOfComment(char[] chars, int index, bool isComment);
        public abstract bool IsEndOfComment(char[] chars, int index);
    }
}
