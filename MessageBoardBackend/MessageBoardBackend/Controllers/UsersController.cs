﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MessageBoardBackend.Models;
//something else
//https://github.com/dotnet/corefx/issues/23604

namespace MessageBoardBackend.Controllers
{

    public class EditProfileData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {

        readonly ApiContext context;

        public UsersController(ApiContext context)
        {
            this.context = context;
        }

        //from the url
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {

            var user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("email or password incorrect");
            }
            return Ok(user);

        }

        [Authorize]
        [HttpGet("me")]
        public ActionResult Get()
        {
            //middleware uses something with (watch chapter 47) and look into nameidentifier, this
            //also this only works because the first one is the tokenidentifer. This should be changed accordingly
            Microsoft.Extensions.Primitives.StringValues authorizationToken = "";
            var con = HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken);

            return Ok(GetSecureUser());
        }

        [Authorize]
        [HttpPost("me")]
        public ActionResult Post([FromBody] EditProfileData profileData)
        {
            //middleware uses something with (watch chapter 47) and look into nameidentifier, this
            //also this only works because the first one is the tokenidentifer. This should be changed accordingly
            //get the userid
            var user = GetSecureUser();
            user.FirstName = profileData.FirstName ?? user.FirstName;
            user.LastName = profileData.LastName ?? user.LastName;
            context.SaveChanges();
            return Ok(user);
        }

        private User GetSecureUser()
        {
            var id = HttpContext.User.Claims.First().Value;
            
            var user = context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }
    }
}