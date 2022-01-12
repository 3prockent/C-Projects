using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_XML
{
    public class Song
    {
        public string Genre { get; set; } = "";
        public string BandName { get; set; } = "";
        public string Album { get; set; } = "";
        public string SongName { get; set; } = "";
        public string Duration { get; set; } = "";
        public string TimeRange { get; set; } = "";
        public string ReleaseYear { get; set; } = "";

        public Song() { }

        public bool isRange(string duration)       //Return result does duration in the 'timeRange'
        {
            switch (TimeRange)
            {
                case "...-3:00":
                    if (String.Compare(duration, "3:00")<=0)
                        return true;
                    return false;
                case "3:01-4:00":
                    if ((String.Compare(duration, "3:01") >= 0) && (String.Compare(duration, "4:00") <= 0))
                        return true;
                    return false;
                case "4:01-5:00":
                    if ((String.Compare(duration, "4:01") >= 0) && (String.Compare(duration, "5:00") <= 0))
                        return true;
                    return false;
                case "5:01-...":
                    if (String.Compare(duration, "5:01") >= 0)
                        return true;
                    return false;
            }
            return false;  
            
        }
    }
}
