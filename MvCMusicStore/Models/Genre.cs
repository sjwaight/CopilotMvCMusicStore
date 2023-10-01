namespace MvcMusicStore.Models
{
    public class Genre
    {
        // add a property of type string that is called Name
        public string Name { get; set; }

        /* Add three fields:
         * GenreId of type int
         *         * Description of type string
         *                 * Albums of type List<Album>
         *                         */
        public int GenreId { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}
