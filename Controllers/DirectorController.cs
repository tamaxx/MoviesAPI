using CinemaAPI.Models;
using MoviesAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesAPI.Controllers
{
    public class DirectorController : ApiController
    {
        // GET: /director
        [HttpGet]
        [Route("director")]
        public IEnumerable<Director> Get()
        {
            DirectorDAO directorDAO = new DirectorDAO();
            List<Director> list_director = directorDAO.List();
            return list_director;
        }

        // GET: /director?id=5
        [HttpGet]
        [Route("director")]
        public Director Get(int id)
        {
            DirectorDAO directorDAO = new DirectorDAO();
            var director = directorDAO.ListSingleDirector(id).FirstOrDefault();

            if(director == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return director;
        }

        // GET: /directorPicture?id=5
        [HttpGet]
        [Route("directorPicture")]
        public string GetDirectorPicture(int id)
        {
            DirectorDAO directorDAO = new DirectorDAO();
            string picture = directorDAO.SelectPicture(id);
            
            return picture;
        }
    }
}
