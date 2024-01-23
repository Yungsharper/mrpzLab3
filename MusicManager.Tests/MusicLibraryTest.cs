using MusicManagement.Library;
using MusicManager.Library;

namespace MusicManager.Tests
{
    public class MusicLibraryTest
    {
        [Fact]
        public void AddGenre_WhenNewGenre_AddsToGenresList()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var newGenre = new Genre("Rock");

            // Act
            musicLibrary.AddGenre(newGenre);

            // Assert
            Assert.Contains(newGenre, musicLibrary.Genres);
        }

        [Fact]
        public void AddGenre_WhenExistingGenre_NotAddedAgain()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");

            // Act
            musicLibrary.AddGenre(genre);
            musicLibrary.AddGenre(genre);

            // Assert
            Assert.Equal(1, musicLibrary.Genres.Count);
        }

        [Fact]
        public void AddGenre_DoesNotAllowEmptyName()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => musicLibrary.AddGenre(new Genre("")));
        }

        [Fact]
        public void AddGenre_DoesNotAllowNullName()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => musicLibrary.AddGenre(new Genre(null)));
        }

        [Fact]
        public void RemoveGenre_RemovesExistingGenre()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");
            musicLibrary.AddGenre(genre);

            // Act
            musicLibrary.RemoveGenre(genre);

            // Assert
            Assert.DoesNotContain(genre, musicLibrary.Genres);
        }

        [Fact]
        public void RemoveGenre_RemovesGenreFromSongs()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");
            musicLibrary.AddGenre(genre);

            var song = new Song("Song", "Artist", genre);
            musicLibrary.AddSong(song);

            // Act
            musicLibrary.RemoveGenre(genre);

            // Assert
            Assert.Equal(Genre.Undefined, song.SongGenre);
        }

        [Fact]
        public void AddSong_WhenNewSong_AddsToSongsList()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var newSong = new Song("Song1", "Artist1", new Genre("Rock"));

            // Act
            musicLibrary.AddSong(newSong);

            // Assert
            Assert.Contains(newSong, musicLibrary.Songs);
        }

        [Fact]
        public void AddSong_WhenExistingSong_NotAddedAgain()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var song = new Song("Song1", "Artist1", new Genre("Rock"));

            // Act
            musicLibrary.AddSong(song);
            musicLibrary.AddSong(song);

            // Assert
            Assert.Equal(1, musicLibrary.Songs.Count);
        }

        [Fact]
        public void AddSong_DoesNotAllowEmptyName()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => musicLibrary.AddSong(new Song("", "Artist1", new Genre("Rock"))));
        }

        [Fact]
        public void AddSong_DoesNotAllowNullName()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => musicLibrary.AddSong(new Song(null, "Artist1", new Genre("Rock"))));
        }

        [Fact]
        public void RemoveSong_RemovesExistingSong()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");
            musicLibrary.AddGenre(genre);

            var song = new Song("Song1", "Artist1", genre);
            musicLibrary.AddSong(song);

            // Act
            musicLibrary.RemoveSong(song);

            // Assert
            Assert.DoesNotContain(song, musicLibrary.Songs);
        }

        [Fact]
        public void RemoveSong_RemovesSongFromFavorites()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");
            musicLibrary.AddGenre(genre);

            var song = new Song("Song1", "Artist1", genre);
            musicLibrary.AddSong(song);
            musicLibrary.AddToFavorites(song);

            // Act
            musicLibrary.RemoveSong(song);

            // Assert
            Assert.DoesNotContain(song, musicLibrary.Favorites);
        }

        [Fact]
        public void AddToFavorites_WhenNewFavorite_AddsToFavoritesList()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var newFavorite = new Song("FavoriteSong", "FavoriteArtist", new Genre("Pop"));

            // Act
            musicLibrary.AddSong(newFavorite);
            musicLibrary.AddToFavorites(newFavorite);

            // Assert
            Assert.Contains(newFavorite, musicLibrary.Favorites);
        }

        [Fact]
        public void AddToFavorites_WhenExistingFavorite_NotAddedAgain()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var favorite = new Song("FavoriteSong", "FavoriteArtist", new Genre("Pop"));

            // Act
            musicLibrary.AddSong(favorite);
            musicLibrary.AddToFavorites(favorite);
            musicLibrary.AddToFavorites(favorite);

            // Assert
            Assert.Equal(1, musicLibrary.Favorites.Count);
        }

        [Fact]
        public void AddToFavorites_DoesNotAllowEmptyName()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => musicLibrary.AddToFavorites(new Song("", "FavoriteArtist", new Genre("Pop"))));
        }

        [Fact]
        public void AddToFavorites_DoesNotAllowNullName()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => musicLibrary.AddToFavorites(new Song(null, "FavoriteArtist", new Genre("Pop"))));
        }

        [Fact]
        public void RemoveFromFavorites_RemovesExistingFavorite()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");
            musicLibrary.AddGenre(genre);

            var favorite = new Song("FavoriteSong", "FavoriteArtist", genre);
            musicLibrary.AddSong(favorite);
            musicLibrary.AddToFavorites(favorite);

            // Act
            musicLibrary.RemoveFromFavorites(favorite);

            // Assert
            Assert.DoesNotContain(favorite, musicLibrary.Favorites);
        }

        [Fact]
        public void GetFavoritesSortedByNameDescending_ReturnsSortedList()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();
            var genre = new Genre("Rock");
            musicLibrary.AddGenre(genre);

            var favorite1 = new Song("FavoriteSong1", "Artist1", genre);
            var favorite2 = new Song("FavoriteSong2", "Artist2", genre);
            var favorite3 = new Song("FavoriteSong3", "Artist3", genre);

            musicLibrary.AddSong(favorite1);
            musicLibrary.AddSong(favorite2);
            musicLibrary.AddSong(favorite3);

            musicLibrary.AddToFavorites(favorite1);
            musicLibrary.AddToFavorites(favorite2);
            musicLibrary.AddToFavorites(favorite3);

            // Act
            var sortedFavorites = musicLibrary.GetFavoritesSortedByNameDescending();

            // Assert
            Assert.Equal(new List<Song> { favorite3, favorite2, favorite1 }, sortedFavorites);
        }

        [Fact]
        public void GetFavoritesSortedByNameDescending_ReturnsEmptyListWhenNoFavorites()
        {
            // Arrange
            var musicLibrary = new MusicManagement.Library.MusicLibrary();

            // Act
            var sortedFavorites = musicLibrary.GetFavoritesSortedByNameDescending();

            // Assert
            Assert.Empty(sortedFavorites);
        }


    }
}