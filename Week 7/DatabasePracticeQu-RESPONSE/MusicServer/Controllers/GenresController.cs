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
        //20160813 JPC HOWTO read configuration data and connectionString in a controller
        private readonly string _appAccessKey;
        private readonly CDQ3_S01_MusicContext _context;

        public GenresController(IConfiguration configuration, CDQ3_S01_MusicContext context)
        {
            _appAccessKey = configuration.GetSection("AppSettings")["appAccessKey"];
            _context = context;
        }

        //test string
        //GET: /genres/getallgenres
        public string GetAllGenres()
        {
            var genres = _context.Genre.ToList();
            string json =  JsonConvert.SerializeObject(genres);
            return json;
        }

        //Test string to retrieve information about "Disco"
        //GET: /genres/getgenre?genreid=5
        public string GetGenre(int genreId)
        {
            var genres = _context.Genre.Where(g => g.GenreId == genreId).ToList();
            var genre = genres[0];
            var json = JsonConvert.SerializeObject(genre);
            return json;
        }

        //POST: /genres/postnewgenre
        [HttpPost]
        public string PostNewGenre(string json)
        {
            var genre = JsonConvert.DeserializeObject<Genre>(json);
            _context.Add(genre);
            _context.SaveChanges();
            return "Data Saved.";
        }

        //POST: /genres/postupdategenre
        [HttpPost]
        public string PostUpdateGenre(string json)
        {
            var genre = JsonConvert.DeserializeObject<Genre>(json);
            _context.Update(genre);
            _context.SaveChanges();
            return "Data Saved.";
        }



    }
}