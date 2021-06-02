using System.Collections.Generic;

namespace EasyDoc.Application.Interfaces
{
    public interface ICommandService
    {
        Dictionary<string, List<string>> ConvertInputToCommandsAndParams(string[] args);
        bool IsValidCommand(string command);
        bool CommandTakesOneParam(string command);
        bool CommandTakesNoParam(string command);
    }
}
