using System;
using System.Collections.Generic;

namespace EasyDoc.Application.Rules
{
    public class JavaDocumentationRule : DocumentationRule
    {
        public JavaDocumentationRule() : base(
            ".java",
            "/**",
            "*/",
            new List<string>()
            {
                "@param",
                "@returns"
            }
            )
        {
        }

        public override bool IsEndOfComment(char[] chars, int index)
        {
            try
            {
                return chars[index] == EndOfComment[0] && chars[index + 1] == EndOfComment[1];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public override bool IsStartOfComment(char[] chars, int index, bool isComment)
        {
            try
            {
                return  chars[index] == StartOfComment[0] &&
                        chars[index + 1] == StartOfComment[1] &&
                        chars[index + 2] == StartOfComment[2] &&
                        !isComment;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
    }
}
