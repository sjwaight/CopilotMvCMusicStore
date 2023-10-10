namespace MvcMusicStore.Models
{
    public class Album
    {
        // add two properties - Title (string) and Genre (Genre)
        public string Title { get; set; }
        public Genre? Genre { get; set; }

        // add these fields - AlbumId (int), Artist (Artist), Price (decimal), AlbumArtUrl (string)
        public int AlbumId { get; set; }
        public Artist? Artist { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

        // add these fields - ArtistId (int), GenreId (int)
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

    }
}
