using EasyDoc.Application.Models;
using EasyDoc.Application.Requests.Documentation;
using EasyDoc.Application.Rules;
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
            var documentationRule = new JavaDocumentationRule();

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
                if (isComment)
                {
                    if (documentationRule.IsEndOfComment(fileChars, i))
                    {
                        isComment = false;
                        i += 2;

                        if (commentCounter == 1)
                        {
                            commentOutput.TopLevelComment = sb.ToString().Trim();
                            continue;
                        }

                        // Check what kind of comment was used
                        var signatureStringBuilder = new StringBuilder();
                        int j = i;

                        while (fileChars[j] != '{' && fileChars[j] != ';')
                        {
                            signatureStringBuilder.Append(fileChars[j]);
                            j++;
                        }
                        string signature = signatureStringBuilder.ToString().Trim();
                        // Must be either Constructor or Method in java
                        if (signature.Contains('(') || signature.Contains(')'))
                        {
                            // Constructor
                            if (signature.Contains(request.FileName))
                            {
                                commentOutput.ConstructorComments = commentOutput.ConstructorComments.Append(new Comment(signature, sb.ToString().Trim()));
                            }
                            // Method
                            else
                            {
                                commentOutput.MethodComments = commentOutput.MethodComments.Append(new Comment(signature, sb.ToString().Trim()));
                            }
                        }
                        else
                        {
                            // Property
                            commentOutput.PropertyComments = commentOutput.PropertyComments.Append(new Comment(signature, sb.ToString().Trim()));
                        }

                        continue;
                    }
                    sb.Append(fileChars[i]);
                }

                if (documentationRule.IsStartOfComment(fileChars, i, isComment))
                {
                    sb = new StringBuilder();
                    i += 2;
                    isComment = true;
                    commentCounter++;
                }
            }
            return commentOutput;
        }
    }
}
