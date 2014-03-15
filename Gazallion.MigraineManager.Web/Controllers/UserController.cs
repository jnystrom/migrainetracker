using Gazallion.MigraineManager.Service.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gazallion.MigraineManager.Data;
using Gazallion.MigraineManager.Data.Models;
using AutoMapper;
using Gazallion.MigraineManager.Common.Data.DTOs;

namespace Gazallion.MigraineManager.Web.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _Service;

        public UserController(IUserService service)
        {
            _Service = service;
        }

        // GET api/values
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            foreach (User user in _Service.GetUsers())
            {
                users.Add(user);
            }
            return users;
        }

        // GET api/values/5
        public UserDto Get(int id)
        {
            return Mapper.Map<User, UserDto>(_Service.GetUser(id));
            
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}