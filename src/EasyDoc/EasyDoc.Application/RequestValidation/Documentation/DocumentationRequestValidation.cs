using EasyDoc.Application.Requests.Documentation;
using EasyDoc.Domain.Errors;
using FluentValidation;

namespace EasyDoc.Application.RequestValidation.Documentation
{
    public class DocumentationRequestValidation : AbstractValidator<DocumentationRequest>
    {
        public DocumentationRequestValidation()
        {
            AddRuleForFileName();
            AddRuleForFileContent();
        }

        protected void AddRuleForFileName()
        {
            RuleFor(req => req.FileName)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.InvalidFileName)
                .WithMessage("Filename may not be empty");
        }

        protected void AddRuleForFileContent()
        {
            RuleFor(req => req.FileContent)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.InvalidFileContent)
                .WithMessage("Filecontent may not be empty");
        }
    }
}
