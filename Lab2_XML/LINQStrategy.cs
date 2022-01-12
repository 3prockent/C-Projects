using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Lab2_XML
{
    public class LINQStrategy : IAnalizatorXMLStrategy
    {
        public XDocument doc;
        public LINQStrategy()
        {
            doc = XDocument.Load(Globals.PATH_TO_XML);
        }

        public List<Song> Search(Song song)
        {
            List<Song> result = new List<Song>();

            var filteredSongs = from node in doc.Descendants("song")        //select noname type filtered by song attribute criteria
                                where
                                (
                                (node.Attribute("Genre").Value.Equals(song.Genre) || song.Genre.Equals(String.Empty)) &&
                                (node.Attribute("BandName").Value.Equals(song.BandName) || song.BandName.Equals(String.Empty)) &&
                                (node.Attribute("Album").Value.Equals(song.Album) || song.Album.Equals(String.Empty)) &&
                                (node.Attribute("SongName").Value.Equals(song.SongName) || song.SongName.Equals(String.Empty)) &&
                                (song.isRange(node.Attribute("Duration").Value) || song.TimeRange.Equals(String.Empty)) &&
                                (node.Attribute("ReleaseYear").Value.Equals(song.ReleaseYear) || song.ReleaseYear.Equals(String.Empty))
                                )
                                select new
                                {
                                    genre = node.Attribute("Genre").Value,
                                    bandName = node.Attribute("BandName").Value,
                                    album = node.Attribute("Album").Value,
                                    songName = node.Attribute("SongName").Value,
                                    duration = node.Attribute("Duration").Value,
                                    releaseYear = node.Attribute("ReleaseYear").Value
                                };

            foreach (var filtSong in filteredSongs)     //add new song to result list
            {
                var resSong = new Song();
                resSong.Genre = filtSong.genre.ToString();
                resSong.BandName = filtSong.bandName.ToString();
                resSong.Album = filtSong.album.ToString();
                resSong.SongName = filtSong.songName.ToString();
                resSong.Duration = filtSong.duration.ToString();
                resSong.ReleaseYear = filtSong.releaseYear.ToString();
                result.Add(resSong);
            }

            return result;
        }
    }
}
