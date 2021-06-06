using EasyDoc.Application.Models;
using EasyDoc.Application.RequestValidation.Documentation;
using EasyDoc.Domain.Core.Commands;
using System;

namespace EasyDoc.Application.Requests.Documentation
{
    public class DocumentationRequest : ReturningCommand<CommentOutput>
    {
        protected DocumentationRequest(
            Guid aggregateId,
            string fileName,
            string fileContent) : base(aggregateId)
        {
            FileName = fileName;
            FileContent = fileContent;
        }

        public string FileName { get; set; }
        public string FileContent { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DocumentationRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
