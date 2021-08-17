using System;
using System.Threading.Tasks;
using ForeCast.API;
using ForeCast.Common;
using System.IO;

namespace ForeCast
{

    public class GribExtractor:IGribExtractor
    {
        private string _path;
        private const string GRIB_FILENAME= "wgrib2.exe";
        private const string GRIB_FOLDER = "wgrib2";
        public GribExtractor()
        {
            _path = Path.Combine(Environment.CurrentDirectory, GRIB_FOLDER, GRIB_FILENAME); 
        }
        public async Task<IForeCastData> ExtractForeCastData(string fileName, IRequestData request)
        {
            string args= $"{fileName} -match \":(TMP:2 m above ground):\" -lon {request.Longitude} {request.Latitude}";

            var result= await new RunProcess().RunProcessAsync(_path, args);

            if(result.ExitValue!=0)
                throw new Exception($"Failed to run grid command. error {result.ExitValue} {result.Error}");
            
            var parser = new GridResultParser();
            parser.Parse(result.Output);

            string value = parser.GetTemperatureValue();
            if (string.IsNullOrEmpty(value))
                throw new Exception("Enable to parse grid result");
            double temp;
            if(double.TryParse(value, out temp))
                return new ForeCastData(Temperature.FromKelvin(temp));
            throw new Exception("Enable to parse temperature");

        }

        
    }

   
}
