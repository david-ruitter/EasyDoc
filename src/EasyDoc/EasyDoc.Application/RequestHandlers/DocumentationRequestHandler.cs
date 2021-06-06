using EasyDoc.Application.Models;
using EasyDoc.Application.Requests.Documentation;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyDoc.Application.RequestHandlers
{
    public class DocumentationRequestHandler :
        IRequestHandler<GetJavaDocumentation, CommentOutput>
    {
        public async Task<CommentOutput> Handle(GetJavaDocumentation request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                request.PrintErrors();
                return null;
            }
            var commentOutput = new CommentOutput();
            var content = request.FileContent.ToCharArray();
            bool isComment = false;
            StringBuilder sb = new StringBuilder();

            int commentCounter = 0;
            for (int i = 0; i < content.Length; i++)
            {
                try
                {
                    if (isComment)
                    {
                        if (content[i] == '*' && content[i + 1] == '/')
                        {
                            isComment = false;
                            i += 2;

                            if (commentCounter == 1)
                            {
                                commentOutput.TopLevelComment = sb.ToString().Trim();
                                continue;
                            }

                            // Check what kind of comment was used
                            StringBuilder typeStringBuilder = new StringBuilder();
                            int j = i;

                            while (content[j] != '{' && content[j] != ';')
                            {
                                typeStringBuilder.Append(content[j]);
                                j++;
                            }
                            string lineOutput = typeStringBuilder.ToString().Trim();
                            // Must be either Constructor or Method in java
                            if (lineOutput.Contains('(') || lineOutput.Contains(')'))
                            {
                                // Constructor
                                if (lineOutput.Contains(request.FileName))
                                {
                                    commentOutput.ConstructorComments.Add(lineOutput, sb.ToString().Trim());
                                }
                                // Method
                                else
                                {
                                    commentOutput.MethodComments.Add(lineOutput, sb.ToString().Trim());
                                }
                            }
                            else
                            {
                                // Property
                                commentOutput.PropertyComments.Add(lineOutput, sb.ToString().Trim());
                            }

                            continue;
                        }
                        sb.Append(content[i]);
                    }

                    if (content[i] == '/' && content[i + 1] == '*' && content[i + 2] == '*' && !isComment)
                    {
                        sb = new StringBuilder();
                        i += 2;
                        isComment = true;
                        commentCounter++;
                    }

                }
                catch (IndexOutOfRangeException e)
                {

                }
            }
            return commentOutput;
        }
    }
}
