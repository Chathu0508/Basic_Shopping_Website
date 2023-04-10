using BackendApplication.Models;
using BackendApplication.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BackendApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        private readonly ICartRepository _cartRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository, ICartRepository cartRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index(string sterm = "", int genreId = 0)
        {
            //it is the Task < IEnumerable < Book >> GetBooks(string sTerm = "", int genreId = 0)
            IEnumerable<Book> books = await _homeRepository.GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };
            return View(bookModel);
            //return View();
        }
        //public async Task<IActionResult> Details(string sterm = "", int genreId = 0)
        //{
        //    //it is the Task < IEnumerable < Book >> GetBooks(string sTerm = "", int genreId = 0)
        //    IEnumerable<Book> books = await _homeRepository.GetBooks(sterm, genreId);
        //    IEnumerable<Genre> genres = await _homeRepository.Genres();
        //    BookDisplayModel bookModel = new BookDisplayModel
        //    {
        //        Books = books,
        //        Genres = genres,
        //        STerm = sterm,
        //        GenreId = genreId
        //    };
        //    return View(bookModel);

        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}