using System.Collections.Generic;

namespace EasyDoc.Application.Rules
{
    public class JavaRules : Rules
    {
        public JavaRules()
        {
            FileExtension = ".java";
            StartOfComment = "/**";
            EndOfComment = "*/";
            CommentTags = new List<string>() 
            {
                "@param", 
                "@returns" 
            };
        }
    }
}
