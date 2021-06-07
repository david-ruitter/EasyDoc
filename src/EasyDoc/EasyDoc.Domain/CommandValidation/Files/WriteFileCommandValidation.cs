using EasyDoc.Domain.Commands.Files;
using EasyDoc.Domain.Errors;
using FluentValidation;

namespace EasyDoc.Domain.CommandValidation.Files
{
    public class WriteFileCommandValidation : AbstractValidator<WriteFileCommand>
    {
        public WriteFileCommandValidation()
        {
            AddRuleForFileName();
            AddRuleForFileContent();
        }

        protected void AddRuleForFileName()
        {
            RuleFor(cmd => cmd.FileName)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.InvalidFileName)
                .WithMessage("Filename may not be empty");
        }

        protected void AddRuleForFileContent()
        {
            RuleFor(cmd => cmd.FileContent)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.InvalidFileContent)
                .WithMessage("Filecontent may not be empty");
        }
    }
}
