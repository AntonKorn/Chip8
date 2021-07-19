﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface ICommandModelActivator
    {
        public void Initialize();
        public ActivationResult ActivateCommandModel(ParsedCommand parsedCommand);
    }
}
