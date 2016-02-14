﻿using System.Collections.Generic;

namespace Symbiote.Core
{
    public interface IConfigurationDefinition
    {
        string Form { get; }
        string Schema { get; }
    }

    public interface IActionResult
    {
        ActionResultCode Result { get; }
        List<string> Messages { get; }
        IActionResult AddInfo(string message);
        IActionResult AddWarning(string message);
        IActionResult AddError(string message);
    }
}