﻿using ABAPAI.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Interfaces.Handlers
{
    public interface IHandler<T> where T:ICommand
    {
        ICommandResult Handle(T command);
    }
}
