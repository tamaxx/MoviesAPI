using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesAPI.Controllers
{
    public class GenreController : ApiController
    {
        [HttpGet]
        [Route("genre")]
        // GET: /genre
        public IEnumerable<Genre> Get()
        {
            GenreDAO genreDAO = new GenreDAO();
            List<Genre> list_genre = genreDAO.List();
            return list_genre;
        }

        // GET: /genre?id=5
        [HttpGet]
        [Route("genre")]
        public Genre Get(int id)
        {
            GenreDAO generoDAO = new GenreDAO();
            var genero = generoDAO.ListSingleGenre(id).FirstOrDefault();

            if (genero == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return genero;
        }
    }
}
