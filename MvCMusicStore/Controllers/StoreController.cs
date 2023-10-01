using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Data;
using MvcMusicStore.Models;
using System.Web;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // add three methods named Index Browse Details

        // add an Ilogger property to the StoreController class
        private readonly ILogger<StoreController> _logger;

        // add a private property for my database context
        private readonly MusicStoreContext _context;

        // create a constructor that accepts and ILogger and a MusicStoreContext object
        public StoreController(ILogger<StoreController> logger, MusicStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        // pass an ILogger object to the StoreController constructor
        //public StoreController(ILogger<StoreController> logger)
        //{
        //    _logger = logger;
        //}
        
        public ActionResult Index() {

            // populte a list of Genres from the database
            var genres = _context.Genres.ToList();

			// create a `List` of type `Genre` that has three entries - "Disco", "Jazz" and "Rock".
            // var genres = new List<Genre>
            // {
			//	new Genre { Name = "Disco" },
			//	new Genre { Name = "Jazz" },
			//	new Genre { Name = "Rock" }
			// };
            // return the list in a View()
            return View(genres);
        }

        public ActionResult Browse(string genre) { 

            // retrieve all the genres from the database and include albums
            var genres = _context.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genres);
            // protect the genre input from JavaScript injection attacks
            //string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            //return message; 
        }

        // a method called Details that returns ActionResult containing an Album object in a View
        public ActionResult Details(int id)
        {
            // load the album from the database using the id and also include the Genre and Artist
            var album = _context.Albums.Include("Genre").Include("Artist").Single(a => a.AlbumId == id);

            //var album = new Album { Title = "Album " + id };
            return View(album); 
        }
    }
}
