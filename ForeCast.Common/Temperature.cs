
namespace ForeCast.Common
{
    public class Temperature
    {
        private double TemperatureInCelsius;
        private const double kelvinOffset = 273.15;
        public static Temperature FromKelvin(double temperature)
        {
            return new Temperature { TemperatureInCelsius = temperature - kelvinOffset };
        }

        public double ToCelsius()
        {
            return TemperatureInCelsius;
        }
    }
}
