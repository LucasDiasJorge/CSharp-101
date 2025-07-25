﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyIntegration.Interfaces
{
    public interface IIntegrationStrategy
    {
        Response IntegrateData(Dictionary<string, object> source, string destination);
    }
}
