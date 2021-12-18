using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MusicServer.Models.DB;
using Newtonsoft.Json;

namespace MusicServer.Controllers
{
    public class GenresController : Controller
    {
        private readonly string _appAccessKey;
        private readonly CDQ3_Michael_MusicContext _context;

        public GenresController(IConfiguration configuration, CDQ3_Michael_MusicContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get All Genres
        public string getAllGenres()
        {
            var genres = _context.Genre.ToList();
            string json = JsonConvert.SerializeObject(genres);
            return json;

        }

        public string getGenre(int genreId)
        {
            var genres = _context.Genre.Where(g => g.GenreId == genreId).ToList();
            var genre = genres[0];
            var json = JsonConvert.SerializeObject(genre);
            return json;
        }
    }
}