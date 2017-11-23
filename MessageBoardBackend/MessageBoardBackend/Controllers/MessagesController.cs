using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessageBoardBackend.Models;

namespace MessageBoardBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        readonly ApiContext context;

        public MessagesController(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Message> Get()
        {
            return context.Messages;
        }


        // pass it in as a string (by using {})
        [HttpGet("{name}")]
        public IEnumerable<Message> Get(string name)
        {
            return context.Messages.Where(message => message.Owner == name);
        }

        [HttpPost]
        //instead of bound by url it is bound by body
        //the json body does not have to be casesensitive to correctly send json like "owner" can be used 
        public Message Post([FromBody] Models.Message message)
        {
            var dbMessage = context.Messages.Add(message).Entity;
            context.SaveChanges();
            //makes sure that the context does have an ID 
            return dbMessage;
        }
    }
}