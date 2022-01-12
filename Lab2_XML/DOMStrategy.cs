using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Lab2_XML
{
    public class DOMStrategy : IAnalizatorXMLStrategy
    {
        XmlDocument doc = new XmlDocument();

        public DOMStrategy()
        {
            doc.Load(Globals.PATH_TO_XML);
        }

        public List<Song> Search(Song song)
        {
            List<Song> result = new List<Song>();
            var childNodes = doc.SelectNodes("//SongDataBase/song");        //Get all songs on 1-st level
            foreach (XmlNode childNode in childNodes)
            {
                string Genre = "";
                string BandName = "";
                string Album = "";
                string SongName = "";
                string Duration = "";
                string ReleaseYear = "";

                foreach (XmlAttribute attribute in childNode.Attributes)
                {
                    if (attribute.Name.Equals("Genre") && (attribute.Value.Equals(song.Genre) || song.Genre.Equals(String.Empty)))
                    {
                        Genre = attribute.Value;
                        // Console.WriteLine("Genre");
                    }

                    if (attribute.Name.Equals("BandName") && (attribute.Value.Equals(song.BandName) || song.BandName.Equals(String.Empty)))
                    {
                        BandName = attribute.Value;
                        //Console.WriteLine("BandName");
                    }

                    if (attribute.Name.Equals("Album") && (attribute.Value.Equals(song.Album) || song.Album.Equals(String.Empty)))
                    {
                        Album = attribute.Value;
                        //Console.WriteLine("Album");
                    }

                    if (attribute.Name.Equals("SongName") && (attribute.Value.Equals(song.SongName) || song.SongName.Equals(String.Empty)))
                    {
                        SongName = attribute.Value;
                        //Console.WriteLine("SongName");
                    }

                    if (attribute.Name.Equals("Duration") && (song.isRange(attribute.Value) || song.TimeRange.Equals(String.Empty)))
                    {
                        Duration = attribute.Value;
                        //Console.WriteLine("Duration");
                    }

                    if (attribute.Name.Equals("ReleaseYear") && (attribute.Value.Equals(song.ReleaseYear) || song.ReleaseYear.Equals(String.Empty)))
                    {
                        ReleaseYear = attribute.Value;
                        //Console.WriteLine("ReleaseYear");
                    }

                }

                if (Genre != "" && BandName != "" && Album != "" && SongName != "" && Duration != "" && ReleaseYear != "")      //Check do all field filled
                {
                    Song resSong = new Song();
                    resSong.Genre = Genre;
                    resSong.BandName = BandName;
                    resSong.Album = Album;
                    resSong.SongName = SongName;
                    resSong.Duration = Duration;
                    resSong.ReleaseYear = ReleaseYear;
                    result.Add(resSong);
                }
            }
            return result;

        }
    }
}
