using System.Collections.Generic;

namespace EasyDoc.Application.Rules
{
    public class Rules
    {
        public string FileExtension { get; set; }
        public string StartOfComment { get; set; }
        public string EndOfComment { get; set; }
        public List<string> CommentTags { get; set; }
    }
}
