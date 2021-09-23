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
    public class PlatformController : ApiController
    {
        // GET: /platform
        [HttpGet]
        [Route("platform")]
        public IEnumerable<Platform> Get()
        {
            PlatformDAO platormDAO = new PlatformDAO();
            List<Platform> list_platform = platormDAO.List();
            return list_platform;
        }

        // GET: /platform?id=5
        [HttpGet]
        [Route("platform")]
        public Platform Get(int id)
        {
            PlatformDAO platformDAO = new PlatformDAO();
            var platform = platformDAO.ListSinglePlatform(id).FirstOrDefault();

            if (platform == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return platform;
        }

        // GET: /platformIcon?id=5
        [HttpGet]
        [Route("platformIcon")]
        public string GetPlatformIcon(int id)
        {
            PlatformDAO platformDAO = new PlatformDAO();
            string icon = platformDAO.SelectIcon(id);

            return icon;
        }
    }
}
