using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardBackend.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role MyRole { get; set; }

        //these do not have to be set
        public virtual Profile Profile { get; set; }
        public virtual Company Company { get; set; }

        public virtual List<JobApplication> JobApplications { get; set; }
        public virtual List<JobPost> JobPosts { get; set; }


    }
}
