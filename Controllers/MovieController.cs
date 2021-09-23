using MoviesAPI.Models;
using MoviesAPI.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesAPI.Controllers
{
    public class MovieController : ApiController
    {
        // GET: /movie
        [HttpGet]
        [Route("movie")]
        public IEnumerable<Movie> Get()
        {
            MovieDAO movieDAO = new MovieDAO();
            List<Movie> list_movie = movieDAO.List();
            return list_movie;
        }

        // GET: /movie?id=5
        [HttpGet]
        [Route("movie")]
        public Movie Get(int id)
        {
            MovieDAO movieDAO = new MovieDAO();
            var movie = movieDAO.ListSingleMovie(id).FirstOrDefault();

            if (movie == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return movie;
        }

        // GET: /moviePoster?id=5
        [HttpGet]
        [Route("moviePoster")]
        public string GetMoviePoster(int id)
        {
            MovieDAO movieDAO = new MovieDAO();
            string movie = movieDAO.SelectPoster(id);

            return movie;
        }

        // GET: /movieByPlatform?name="netflix"
        [HttpGet]
        [Route("movieByPlatform")]
        public List<Movie> GetMovieByPlatorm(string namePlatform)
        {
            MovieDAO movieDAO = new MovieDAO();
            var movie = movieDAO.SelectByPlatform(namePlatform);

            return movie;
        }
    }
}
