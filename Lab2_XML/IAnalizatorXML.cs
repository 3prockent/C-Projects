using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_XML
{
    public interface IAnalizatorXMLStrategy
    {
        public List<Song> Search(Song song);
    }
}
