using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMusicStore.Models;

namespace MvcMusicStore.Data
{
    public class DbInitializer
    {
        /* add a public static void Iniatlize method that takes MusicStoreContext as a parameter
         *         * and returns void
         *                 */
        public static void Initialize(MusicStoreContext context)
        {
            context.Database.EnsureCreated();

            // look if there are any Albums, Genres or Artists in the database
            if (context.Albums.Any() || context.Genres.Any() || context.Artists.Any())
            {
                // if there are, return
                return;
            }

            // create an array of 20 Genre objects
            var genres = new Genre[]
            {
                new Genre { Name = "Rock", Description = "Rock music" },
                new Genre { Name = "Jazz", Description = "Jazz music" },
                new Genre { Name = "Metal", Description = "Metal music" },
                new Genre { Name = "Alternative", Description = "Alternative music" },
                new Genre { Name = "Disco", Description = "Disco music" },
                new Genre { Name = "Blues", Description = "Blues music" },
                new Genre { Name = "Latin", Description = "Latin music" },
                new Genre { Name = "Reggae", Description = "Reggae music" },
                new Genre { Name = "Pop", Description = "Pop music" },
                new Genre { Name = "Classical", Description = "Classical music" }
            };

    
            // add the Genre objects to the Genre context and save to the database
            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();
    
            // create an array of 20 Artist objects
            var artists = new Artist[]
            {
                new Artist { Name = "Aaron Copland & London Symphony Orchestra" },
                new Artist { Name = "Aaron Goldberg" },
                new Artist { Name = "AC/DC" },
                new Artist { Name = "Accept" },
                new Artist { Name = "Adrian Leaper & Doreen de Feis" },
                new Artist { Name = "Aerosmith" },
                new Artist { Name = "Aisha Duo" },
                new Artist { Name = "Alanis Morissette" },
                new Artist { Name = "Alberto Turco & Nova Schola Gregoriana" },
                new Artist { Name = "Alice In Chains" },
                new Artist { Name = "Amy Winehouse" },
                new Artist { Name = "Anita Ward" },
                new Artist { Name = "Antal Doráti & London Symphony Orchestra" },
                new Artist { Name = "Antônio Carlos Jobim" },
                new Artist { Name = "Apocalyptica" },
                new Artist { Name = "Audioslave" },
                new Artist { Name = "BackBeat" },
                new Artist { Name = "Barry Wordsworth & BBC Concert Orchestra" },
                new Artist { Name = "Bee Gees" },
                new Artist { Name = "Berlin Philharmonic & Hans Rosbaud" }
            };  

            // add the Artist objects to the Artist context and save to the database
            foreach (Artist a in artists)
            {
                context.Artists.Add(a);
            }
            context.SaveChanges();


            // create an array of 10 Album objects using our Genre and Artist information
            var albums = new Album[]
            {
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Miles Ahead", Genre = genres[0], Price = 8.99M, Artist = artists[0], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "For Those About To Rock We Salute You", Genre = genres[1], Price = 8.99M, Artist = artists[2], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Let There Be Rock", Genre = genres[1], Price = 8.99M, Artist = artists[2], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Balls to the Wall", Genre = genres[2], Price = 8.99M, Artist = artists[3], AlbumArtUrl = "/images/placeholder.gif" },
                new Album { Title = "Restless and Wild", Genre = genres[2], Price = 8.99M, Artist = artists[3], AlbumArtUrl = "/images/placeholder.gif" }
            };

            // add the Album objects to the Album context and save to the database
            foreach (Album a in albums)
            {
                context.Albums.Add(a);
            }
            context.SaveChanges();
        }
    }
}
