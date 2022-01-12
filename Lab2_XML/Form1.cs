using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace Lab2_XML
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitAllBoxes();
        }


        private void AddItems(XmlNode n)        //Check unique variants in checkbox and add
        {
            if (!GenreBox.Items.Contains(n.SelectSingleNode("@Genre").Value))
                GenreBox.Items.Add(n.SelectSingleNode("@Genre").Value);

            if (!BandNameBox.Items.Contains(n.SelectSingleNode("@BandName").Value))
                BandNameBox.Items.Add(n.SelectSingleNode("@BandName").Value);

            if (!AlbumBox.Items.Contains(n.SelectSingleNode("@Album").Value))
                AlbumBox.Items.Add(n.SelectSingleNode("@Album").Value);

            if (!SongNameBox.Items.Contains(n.SelectSingleNode("@SongName").Value))
                SongNameBox.Items.Add(n.SelectSingleNode("@SongName").Value);

            if (!ReleaseYearBox.Items.Contains(n.SelectSingleNode("@ReleaseYear").Value))
                ReleaseYearBox.Items.Add(n.SelectSingleNode("@ReleaseYear").Value);
        }

        public void InitAllBoxes()       //Filling ComboBoxed with variants 
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(Globals.PATH_TO_XML);

            XmlElement xRoot = doc.DocumentElement;
            XmlNodeList childNodes = xRoot.SelectNodes("song");

            
            foreach (XmlNode node in childNodes)
            {
                AddItems(node);
            }

            string[] DurationRange = { "...-3:00", "3:01-4:00", "4:01-5:00", "5:01-..." };
            foreach (string durTime in DurationRange)
            {
                DurationBox.Items.Add(durTime);
            }
            DOM.Checked = true;
        }

        private void Genre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private Song GetSongByCriteria()
        {
            ResultBox.Text = "";
            Song filteredSong = new Song();

            
            if (GenreCheck.Checked)
                filteredSong.Genre = GenreBox.SelectedItem.ToString();

            if (BandNameCheck.Checked)
                filteredSong.BandName = BandNameBox.SelectedItem.ToString();

            if (AlbumCheck.Checked)
                filteredSong.Album = AlbumBox.SelectedItem.ToString();

            if (SongNameCheck.Checked)
                filteredSong.SongName = SongNameBox.SelectedItem.ToString();

            if (DurationCheck.Checked)
                filteredSong.TimeRange = DurationBox.SelectedItem.ToString();

            if (ReleaseYearCheck.Checked)
                filteredSong.ReleaseYear = ReleaseYearBox.SelectedItem.ToString();

            return filteredSong;
        }

        public List<Song> GetFilteredSongs()
        {
            IAnalizatorXMLStrategy analizator = new DOMStrategy();         //By default

            if (SAX.Checked)
                analizator = new SAXStrategy();

            if (LINQ.Checked)
                analizator = new LINQStrategy();

            Song filterSong = GetSongByCriteria();

            return analizator.Search(filterSong);

        }



        private void Search_Click(object sender, EventArgs e)
        {
            List<Song> filteredSongs = GetFilteredSongs();

            foreach (Song song_ in filteredSongs)
            {
                ResultBox.Text += "Genre: " + song_.Genre + '\n';
                ResultBox.Text += "BandName: " + song_.BandName + '\n';
                ResultBox.Text += "Album: " + song_.Album + '\n';
                ResultBox.Text += "SongName: " + song_.SongName + '\n';
                ResultBox.Text += "Duration: " + song_.Duration + '\n';
                ResultBox.Text += "ReleaseYear: " + song_.ReleaseYear + '\n';
                ResultBox.Text += "\n";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {

            ResultBox.Text = "";
            GenreBox.Text = null;
            GenreCheck.Checked = false;
            BandNameBox.Text = null;
            BandNameCheck.Checked = false;
            AlbumBox.Text = null;
            AlbumCheck.Checked = false;
            SongNameBox.Text = null;
            SongNameCheck.Checked = false;
            DurationBox.Text = null;
            DurationCheck.Checked = false;
            ReleaseYearBox.Text = null;
            ReleaseYearCheck.Checked = false;
            SAX.Checked = false;
            LINQ.Checked = false;
        }       //Clear all checkBoxes

        private void CreateXMLbyCriteria(List<Song> songBase, string savePath)       //create XML to 'savePath'
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null));
            
            var root = xmlDoc.CreateElement("SongDataBase");
            xmlDoc.AppendChild(root);
            foreach (Song song in songBase)
            {
                XmlElement childElement;
                childElement = xmlDoc.CreateElement("song");
                //append to element 'SongName' attribute
                XmlAttribute childAttribute = xmlDoc.CreateAttribute("SongName");
                childAttribute.Value = song.SongName;
                childElement.Attributes.Append(childAttribute);
                //"BandName"
                childAttribute = xmlDoc.CreateAttribute("BandName");
                childAttribute.Value = song.BandName;
                childElement.Attributes.Append(childAttribute);
                //"Genre"
                childAttribute = xmlDoc.CreateAttribute("Genre");
                childAttribute.Value = song.Genre;
                childElement.Attributes.Append(childAttribute);
                //"Album"
                childAttribute = xmlDoc.CreateAttribute("Album");
                childAttribute.Value = song.Album;
                childElement.Attributes.Append(childAttribute);
                //"Duration"
                childAttribute = xmlDoc.CreateAttribute("Duration");
                childAttribute.Value = song.Duration;
                childElement.Attributes.Append(childAttribute);
                //"ReleaseYear"
                childAttribute = xmlDoc.CreateAttribute("ReleaseYear");
                childAttribute.Value = song.ReleaseYear;
                childElement.Attributes.Append(childAttribute);
                //append to root node
                root.AppendChild(childElement);         
            }
            xmlDoc.Save(savePath);
        }
        private void Transform_Click(object sender, EventArgs e)
        {
            var filteredSong = GetFilteredSongs();
            CreateXMLbyCriteria(filteredSong, Globals.PATH_TO_FilteredXML);     //create temp XML file(Path_TO_FilteredXML) with filtered Song DB
            //create and init XML Tranformator
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(Globals.PATH_TO_XSL);                                  
            
            xsl.Transform(Globals.PATH_TO_FilteredXML, Globals.PATH_TO_HTML);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GetAllSongs();
        }
    }
}