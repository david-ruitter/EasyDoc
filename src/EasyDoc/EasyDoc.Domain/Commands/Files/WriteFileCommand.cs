#nullable enable
using EasyDoc.Domain.CommandValidation.Files;
using EasyDoc.Domain.Core.Commands;
using System;

namespace EasyDoc.Domain.Commands.Files
{
    public class WriteFileCommand : Command
    {
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public string? FilePath { get; set; }

        public WriteFileCommand(
            Guid aggregateId,
            string fileContent,
            string fileName,
            string? filePath) : base(aggregateId)
        {
            FileContent = fileContent;
            FileName = fileName;
            FilePath = filePath;
        }

        public override bool IsValid()
        {
            ValidationResult = new WriteFileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
