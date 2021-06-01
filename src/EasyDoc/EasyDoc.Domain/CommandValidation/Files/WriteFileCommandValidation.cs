using EasyDoc.Domain.Commands.Files;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDoc.Domain.CommandValidation.Files
{
    public class WriteFileCommandValidation : AbstractValidator<WriteFileCommand>
    {
        public WriteFileCommandValidation()
        {

        }

        protected void AddRuleForFileName()
        {
            
        }
    }
}
