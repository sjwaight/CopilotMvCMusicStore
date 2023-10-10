using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MvcMusicStore.Data;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        // add database context
        private readonly MusicStoreContext _context;
        private readonly ILogger<StoreManagerController> _logger;

        // add a constructor that accepts a MusicStoreContext object and an ILogger object
        public StoreManagerController(MusicStoreContext context, ILogger<StoreManagerController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // add an index method that retrieves all the albums including Artist and Genre and returns them in a View
        public ActionResult Index()
        {
            // retrieve all the albums from the database and include the Genre and Artist
            var albums = _context.Albums.Include("Genre").Include("Artist").ToList();
            return View(albums);
        }

        // add a create method for the Album entity
        public ActionResult Create()
        {
            // add logic to create the album entity in the database
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name");
            return View();
        }

        /* Add a Create method that accepts HTTP post and an Album object. If the ModelState is valid, save the Album
         * to the database and redirect to the Index action. If the ModelState is not valid, return the View with the
         * ViewBag properties set to the GenreId and ArtistId SelectList objects. */
        [HttpPost]
        public ActionResult Create(Album album)
        {
            // add logic to create the album entity in the database
            if (ModelState.IsValid)
            {
                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
        
        // add a read method for the Album entity
        public void Read(Album album)
        {
            // add logic to read the album entity from the database

        }

        // add an update method for the Album entity
        public void Update(Album album)
        {
            // add logic to update the album entity in the database

        }

        // add a delete method for the Album entity
        public void Delete(Album album)
        {
            // add logic to delete the album entity from the database

        }


    }
}
