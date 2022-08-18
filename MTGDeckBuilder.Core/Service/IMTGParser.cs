﻿using MTGDeckBuilder.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface IMTGParser
    {
        Task<DataFile> ParseMTGFile(string filePath);
    }
}
