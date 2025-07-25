﻿using StrategyIntegration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyIntegration.IntegrationClasses
{
    public class FirstIntegration : IIntegrationStrategy
    {
        public Response IntegrateData(Dictionary<string, object> source, string destination)
        {
            Console.WriteLine("FirstIntegration: Processing data integration...");

            string formattedSource = string.Join(", ", source.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
            Console.WriteLine($"Integrating data from source: {{ {formattedSource} }} to destination: {destination}");
            
            Response response = new Response(1, "Data integration successful.");

            return response;
        }
    }
}
