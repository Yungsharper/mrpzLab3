using MusicManager.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagement.Library
{
    public class MusicLibrary
    {
        public List<Genre> Genres { get; set; }

        public List<Song> Songs { get; set; }

        public List<Song> Favorites { get; set; }

        public MusicLibrary()
        {
            Songs = new List<Song>();
            Genres = new List<Genre>();
            Favorites = new List<Song>();
        }

        public void AddGenre(Genre genre)
        {
            if (string.IsNullOrWhiteSpace(genre?.Name))
            {
                throw new ArgumentException("Genre name cannot be empty or null", nameof(genre));
            }

            if (!Genres.Any(g => g.Name == genre.Name))
            {
                Genres.Add(genre);
            }
        }

        public void RemoveGenre(Genre genre)
        {
            Genres.Remove(genre);

            foreach (var song in Songs)
            {
                if (song.SongGenre == genre)
                {
                    song.SongGenre = Genre.Undefined;
                }
            }
        }

        public void AddSong(Song song)
        {
            if (string.IsNullOrWhiteSpace(song?.Name))
            {
                throw new ArgumentException("Song name cannot be empty or null", nameof(song));
            }

            if (!Songs.Any(s => s.Name == song.Name))
            {
                Songs.Add(song);
            }
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
            Favorites.Remove(song);
        }

        public void AddToFavorites(Song song)
        {
            if (string.IsNullOrWhiteSpace(song?.Name))
            {
                throw new ArgumentException("Song name cannot be empty or null", nameof(song));
            }

            if (Songs.Contains(song) && !Favorites.Any(f => f.Name == song.Name))
            {
                Favorites.Add(song);
            }
        }

        public void RemoveFromFavorites(Song song)
        {
            Favorites.Remove(song);
        }

        public List<Song> GetFavoritesSortedByNameDescending()
        {
            return Favorites.OrderByDescending(song => song.Name).ToList();
        }

        
    }
}
