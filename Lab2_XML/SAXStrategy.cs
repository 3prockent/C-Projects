using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2_XML
{
    class SAXStrategy : IAnalizatorXMLStrategy
    {
        public XmlReader reader;

        public SAXStrategy()
        {
            reader = XmlReader.Create(Globals.PATH_TO_XML);
        }

        public List<Song> Search(Song song)
        {
            List<Song> result = new List<Song>();
            string Genre = "";
            string BandName = "";
            string Album = "";
            string SongName = "";
            string Duration = "";
            string ReleaseYear = "";

            while (reader.Read())
            {
                if (reader.HasAttributes)
                {

                    Genre = "";
                    BandName = "";
                    Album = "";
                    SongName = "";
                    Duration = "";
                    ReleaseYear = "";
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name.Equals("Genre") && (reader.Value.Equals(song.Genre) || song.Genre.Equals(String.Empty)))
                            Genre = reader.Value;



                        if (reader.Name.Equals("BandName") && (reader.Value.Equals(song.BandName) || song.BandName.Equals(String.Empty)))
                            BandName = reader.Value;

                        if (reader.Name.Equals("Album") && (reader.Value.Equals(song.Album) || song.Album.Equals(String.Empty)))
                            Album = reader.Value;

                        if (reader.Name.Equals("SongName") && (reader.Value.Equals(song.SongName) || song.SongName.Equals(String.Empty)))
                            SongName = reader.Value;

                        if (reader.Name.Equals("Duration") && (song.isRange(reader.Value) || song.TimeRange.Equals(String.Empty)))
                            Duration = reader.Value;

                        if (reader.Name.Equals("ReleaseYear") && (reader.Value.Equals(song.ReleaseYear) || song.ReleaseYear.Equals(String.Empty)))
                            ReleaseYear = reader.Value;
                    }

                    if (Genre != "" && BandName != "" && Album != "" && SongName != "" && Duration != "" && ReleaseYear != "")
                    {
                        Song newSong = new Song();
                        newSong.Genre = Genre;
                        newSong.BandName = BandName;
                        newSong.Album = Album;
                        newSong.SongName = SongName;
                        newSong.Duration = Duration;
                        newSong.ReleaseYear = ReleaseYear;
                        result.Add(newSong);
                    }

                }
            }
            reader.Close();
            return result;
        }
    }
}
