using System;
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

    public class EditCompanyData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    [Produces("application/json")]
    [Route("api/companies")]
    public class CompaniesController : Controller
    {

        readonly ApiContext context;

        public CompaniesController(ApiContext context)
        {
            this.context = context;
        }

        //from the url only a company is allowed to get information about itself
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {

            var company = context.Companies.SingleOrDefault(u => u.Id == id);
            if (company == null)
            {
                return NotFound("email or password incorrect");
            }
            return Ok(company);

        }
        

     
    }
}