using MusicManager.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagement.Library
{
    public class Song
    {
        public static readonly string UndefinedAuthor = "Undefined";
        public string Name { get; set; }
        public string Author { get; set; }
        public Genre SongGenre { get; set; }

        public Song(string name, string author = null, Genre genre = null)
        {
            Name = name;
            Author = author ?? UndefinedAuthor;
            SongGenre = genre ?? Genre.Undefined;
        }
    }
}
