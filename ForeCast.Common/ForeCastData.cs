using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast.Common
{
    public class ForeCastData:IForeCastData
    {
        private const double kelvinOffset = 273.15;
        public Temperature Temperature { get; set; }
        public ForeCastData(Temperature temperature)
        {
            Temperature = temperature;
        }
       
    }
}
