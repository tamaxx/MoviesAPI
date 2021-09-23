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
    public class UserController : ApiController
    {
        // GET: /user
        [HttpGet]
        [Route("user")]
        public IEnumerable<User> Get()
        {
            UserDAO userDAO = new UserDAO();
            List<User> list_user = userDAO.List();
            return list_user;
        }

        // GET: /user?=5
        [HttpGet]
        [Route("user")]
        public User Get(int id)
        {
            UserDAO userDAO = new UserDAO();
            var user = userDAO.ListSingleUser(id).FirstOrDefault();

            if (user == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return user;
        }

        // GET: /userPicture?id=5
        [HttpGet]
        [Route("userPicture")]
        public string GetUserPicture(int id)
        {
            UserDAO userDAO = new UserDAO();
            string picture = userDAO.SelectPicture(id);

            return picture;
        }

        // POST: /userSignUp
        [HttpPost]
        [Route("userSignUp")]
        public Boolean Post([FromBody]List<User> list_user)
        {
            UserDAO userDAO = new UserDAO();

            if(list_user == null)
            {
                return false;
            }
            
            foreach (User user in list_user)
            {
                userDAO.SignUp(user);
            }
            return true;
        }

        // PUT: api/User/5
        [HttpPut]
        [Route("userUpdate")]
        public Boolean Put(int id, [FromBody]List<User> list_user)
        {
            UserDAO userDAO = new UserDAO();
            User oldUser = userDAO.ListSingleUser(id).FirstOrDefault();

            if(list_user == null)
            {
                return false;
            }

            userDAO.Update(oldUser, list_user.First().getParameters());
            return true;
        }

        // DELETE: /userDelete?id=5
        [HttpDelete]
        [Route("userDelete")]
        public void Delete(int id)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.Delete(id);
        }
    }
}
