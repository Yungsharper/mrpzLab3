using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Library
{
    public class Genre
    {
        public static readonly Genre Undefined = new Genre("Undefined");
        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}