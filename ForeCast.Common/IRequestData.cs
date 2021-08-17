using System;

namespace ForeCast.Common
{
    public interface IRequestData
    {
        DateTime Date { get; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}