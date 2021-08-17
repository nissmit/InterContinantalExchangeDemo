using System;

namespace ForeCast.Common
{
    public class RequestData:IRequestData
    {
        public DateTime Date { get; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Offset { get; }
        public DateTime RequestTime { get; }

        public RequestData(DateTime date)
        {
            Date = date;
            if(date>DateTime.Today)
                RequestTime = DateTime.Today;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Date.GetHashCode();
                hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Offset.GetHashCode();
                return hashCode;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as RequestData);
        }

        public bool Equals(RequestData obj)
        {
            return obj != null
                && obj.Date == this.Date
                && obj.Latitude == this.Latitude
                && obj.Longitude == this.Longitude
                && obj.Offset == this.Offset;
        }
    }
}