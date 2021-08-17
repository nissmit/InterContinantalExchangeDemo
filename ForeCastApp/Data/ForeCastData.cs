using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeCastApp.Data
{
    public class ForeCastResult
    {
        public double Temperature { get; }
        public ForeCastResult(double temperature)
        {
            Temperature = temperature;
        }
    }
}
