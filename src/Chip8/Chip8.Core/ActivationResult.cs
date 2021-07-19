using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class ActivationResult
    {
        public ParsedCommand ParsedCommand { get; }
        public object ActivatedModel { get; }

        public ActivationResult(ParsedCommand parsedCommand, object activatedModel)
        {
            ParsedCommand = parsedCommand;
            ActivatedModel = activatedModel;
        }
    }
}
