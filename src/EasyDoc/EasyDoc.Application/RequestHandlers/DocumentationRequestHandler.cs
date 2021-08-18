using EasyDoc.Application.Models;
using EasyDoc.Application.Requests.Documentation;
using MediatR;
using System;
using System.Linq;
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
            var commentOutput = new CommentOutput()
            {
                Name = request.FileName
            };
            char[] fileChars = request.FileContent.ToCharArray();
            bool isComment = false;
            var sb = new StringBuilder();

            int commentCounter = 0;
            for (int i = 0; i < fileChars.Length; i++)
            {
                try
                {
                    if (isComment)
                    {
                        if (fileChars[i] == '*' && fileChars[i + 1] == '/')
                        {
                            isComment = false;
                            i += 2;

                            if (commentCounter == 1)
                            {
                                commentOutput.TopLevelComment = sb.ToString().Trim();
                                continue;
                            }

                            // Check what kind of comment was used
                            var typeStringBuilder = new StringBuilder();
                            int j = i;

                            while (fileChars[j] != '{' && fileChars[j] != ';')
                            {
                                typeStringBuilder.Append(fileChars[j]);
                                j++;
                            }
                            string lineOutput = typeStringBuilder.ToString().Trim();
                            // Must be either Constructor or Method in java
                            if (lineOutput.Contains('(') || lineOutput.Contains(')'))
                            {
                                // Constructor
                                if (lineOutput.Contains(request.FileName))
                                {
                                    commentOutput.ConstructorComments = commentOutput.ConstructorComments.Append(new Comment(lineOutput, sb.ToString().Trim()));
                                }
                                // Method
                                else
                                {
                                    commentOutput.MethodComments = commentOutput.MethodComments.Append(new Comment(lineOutput, sb.ToString().Trim()));
                                }
                            }
                            else
                            {
                                // Property
                                commentOutput.PropertyComments = commentOutput.PropertyComments.Append(new Comment(lineOutput, sb.ToString().Trim()));
                            }

                            continue;
                        }
                        sb.Append(fileChars[i]);
                    }

                    if (fileChars[i] == '/' && fileChars[i + 1] == '*' && fileChars[i + 2] == '*' && !isComment)
                    {
                        sb = new StringBuilder();
                        i += 2;
                        isComment = true;
                        commentCounter++;
                    }

                }
                catch (IndexOutOfRangeException e) { }
            }
            return commentOutput;
        }
    }
}
