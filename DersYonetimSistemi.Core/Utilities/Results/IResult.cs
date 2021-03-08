﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Core.Utilities.Results
{
    //Temel void için başlangıç
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
