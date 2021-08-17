using System.Collections.Generic;

namespace ForeCast
{
    internal class GridResultParser
    {
        private const string VALUE = "val";
        private Dictionary<string, string> values = new Dictionary<string, string>();
        public GridResultParser()
        {
        }
        public void Parse(string data)
        {
            values.Clear();
            var relevantData = data.Split(':');
            if(relevantData.Length>1)
            {
                foreach (string s in relevantData[2].Split("\n")[0].Split(','))
                {
                    var splitted = s.Split('=');
                    if (splitted.Length > 1)
                        values.Add(splitted[0], splitted[1]);
                }
            }
            
        }
        public string GetTemperatureValue()
        {
            if (values.ContainsKey(VALUE))
                return values[VALUE];
            return string.Empty;
        }
    }
}