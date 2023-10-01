using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;

namespace MvcMusicStore.Data
{
    public class MusicStoreContext : DbContext
    {
        // add a constructor that takes a DbContextOptions<MusicStoreContext> object and passes it to the base constructor
        public MusicStoreContext(DbContextOptions<MusicStoreContext> options) : base(options)
        {
        }

        // add three properties of type DbSet for Album, Genre and Artist
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }

        // add an OnModelCreating method that maps our three entities to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Artist>().ToTable("Artist");
        }
    }
}
